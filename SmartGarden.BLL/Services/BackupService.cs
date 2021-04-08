using Microsoft.Data.SqlClient;
using SmartGarden.BLL.Interfaces;
using System;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services
{
	public class BackupService : IBackupService
	{
        private const string backupsFolder = @"C:\Backups\";
		private readonly string connectionString;

        public string BackupsFolder => backupsFolder;

		public BackupService(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public async Task<string> CreateBackupAsync()
		{
            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            var backupFileName = String.Format("{0}{1}-{2}.bak",
                backupsFolder, sqlConStrBuilder.InitialCatalog,
                DateTime.Now.ToString("yyyy-MM-dd"));

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                    sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }

            return backupFileName;
        }
	}
}
