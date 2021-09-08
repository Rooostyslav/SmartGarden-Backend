using SmartGarden.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SmartGarden.BLL.Validations.Users
{
	public class ExistEmailForUpdateAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IUserService userService =
					(IUserService)validationContext.GetService(typeof(IUserService));

				Type type = validationContext.ObjectInstance.GetType();
				PropertyInfo piId = type.GetProperty("Id");
				int userId = (int)piId.GetValue(validationContext.ObjectInstance, null);

				var user = userService.FindByIdAsync(userId).Result;
				
				if (user == null)
				{
					return new ValidationResult("User does not exist.", new List<string>() { "Id" });
				}

				string newEmail = value.ToString();

				if (user.Email != newEmail)
				{
					bool exist = userService.ExistEmailAsync(newEmail).Result;
					if (exist)
					{
						return new ValidationResult(ErrorMessage);
					}
				}
			}

			return ValidationResult.Success;
		}
	}
}
