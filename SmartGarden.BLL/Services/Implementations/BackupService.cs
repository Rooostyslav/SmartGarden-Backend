using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class BackupService : IBackupService
	{
        private const string backupsFolder = @"C:\Backups\";
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;
        private readonly string connectionString;
        private readonly string connectionStringToMaster;

        public string BackupsFolder => backupsFolder;

		public BackupService(string connectionString, string connectionStringToMaster)
		{
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            this.connectionString = connectionString;
            this.connectionStringToMaster = connectionStringToMaster;
		}

        public IEnumerable<string> FindAllBackupsFileNames()
        {
            string[] filesWithPaths = Directory.GetFiles(backupsFolder);
            return filesWithPaths.Select(file => Path.GetFileName(file));
        }

        public async Task<string> CreateBackupAsync()
		{
            var backupFileName = String.Format("{0}{1}-{2}_{3}.bak", 
                backupsFolder, 
                sqlConnectionStringBuilder.InitialCatalog,
                DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.ToString("HH-mm"));

            var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                    sqlConnectionStringBuilder.InitialCatalog,
                    backupFileName);

            await ExecuteQueryAsync(query, connectionString);

            return backupFileName;
        }

		public async Task ApplyBackup(string backupFileName)
		{
            var query = String.Format("RESTORE DATABASE {0} FROM " +
                "DISK='C:\\Backups\\{1}' WITH REPLACE",
                sqlConnectionStringBuilder.InitialCatalog,
                backupFileName);

            await ExecuteQueryAsync(query, connectionStringToMaster);
        }

        public async Task<int> ExecuteQueryAsync(string query, string connectionString)
		{
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
	}
}
