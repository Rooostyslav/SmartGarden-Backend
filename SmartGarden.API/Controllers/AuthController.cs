using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.BusinessModels.Auth;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartGarden.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> authOptions;
		private readonly IUserService userService;

		public AuthController(IOptions<AuthOptions> authOptions,
			IUserService userService)
		{
			this.authOptions = authOptions;
			this.userService = userService;
		}

		[Route("login")]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] Login login)
		{
			var user = await userService.FindAsync(login);
			if (user != null)
			{
				var token = GenerateJWT(user);

				return Ok(new
				{
					access_token = token
				});
			}

			return BadRequest("Error email or password!");
		}

		private string GenerateJWT(UserDTO user)
		{
			var authParams = authOptions.Value;

			var securityKey = authParams.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email)
			};

			string role = user.Role.ToString().ToLower();
			claims.Add(new Claim("role", role));

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
