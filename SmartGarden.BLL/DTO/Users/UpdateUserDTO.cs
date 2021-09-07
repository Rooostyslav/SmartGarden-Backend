﻿using SmartGarden.BLL.DTO.Common;
using System.ComponentModel.DataAnnotations;

namespace SmartGarden.BLL.DTO.Users
{
	public class UpdateUserDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string SecondName { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public RoleDTO Role { get; set; }
	}
}