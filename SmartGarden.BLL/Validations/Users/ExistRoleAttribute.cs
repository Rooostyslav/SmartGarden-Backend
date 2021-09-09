using SmartGarden.DAL.Entity.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.Validations.Users
{
	public class ExistRoleAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				bool isDefined = Enum.IsDefined(typeof(Role), value);
				if (!isDefined)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
