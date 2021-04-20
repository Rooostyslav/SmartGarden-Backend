using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.BusinessModels
{
	public class Login
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
