using System;
using System.Security.Claims;

namespace SmartGarden.API.Claims
{
	public static class UserClaims
	{
		public static int Id(this ClaimsPrincipal claims)
		{
			Int32.TryParse(claims
				.FindFirstValue(ClaimsIdentity.DefaultNameClaimType + "identifier"), out int id);
			return id;
		}

	}
}
