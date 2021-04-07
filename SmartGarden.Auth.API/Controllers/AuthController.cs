using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartGarden.Auth.Common;
using SmartGarden.BLL.BusinessModels;
using SmartGarden.BLL.DTO.Users;
using SmartGarden.BLL.Interfaces;

namespace SmartGarden.Auth.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> authOptions;
		private readonly IUserService userService;

		public AuthController(IOptions<AuthOptions> authOptions, IUserService userService)
		{
			this.authOptions = authOptions;
			this.userService = userService;
		}

		[Route("login")]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] Login login)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await userService.FindUserAsync(login);

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

			claims.Add(new Claim("role", user.Role));

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
