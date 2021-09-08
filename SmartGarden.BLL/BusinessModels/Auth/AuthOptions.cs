﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SmartGarden.BLL.BusinessModels.Auth
{
	public class AuthOptions
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Secret { get; set; }
		public int Tokenlifetime { get; set; }

		public SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
		}
	}
}
