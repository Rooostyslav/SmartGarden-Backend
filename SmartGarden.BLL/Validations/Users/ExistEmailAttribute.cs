using SmartGarden.BLL.Services;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.Validations.Users
{
	public class ExistEmailAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IUserService userService =
					(IUserService)validationContext.GetService(typeof(IUserService));

				bool exist = userService.ExistEmailAsync(value.ToString()).Result;
				if (exist)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
