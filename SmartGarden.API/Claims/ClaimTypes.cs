using System.Security.Claims;

namespace SmartGarden.API.Claims
{
	public static class ClaimTypes
	{
		public static string Id => ClaimsIdentity.DefaultNameClaimType + "identifier";

	}
}
