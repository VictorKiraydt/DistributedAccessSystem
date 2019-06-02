using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DASApi.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DASApi.Core.Repositories.Interfaces;

namespace DASApi.Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public IConfiguration Configuration { get; }
		private readonly IUserRepository _userRepo;

		public AuthController(IConfiguration configuration, IUserRepository userRepo)
		{
			Configuration = configuration;
			_userRepo = userRepo;
		}

		// GET api/values
		[AllowAnonymous]
		[HttpPost, Route("login")]
		public IActionResult Login([FromBody]UserModel loginInfo)
		{
			if (loginInfo == null)
			{
				return BadRequest("Invalid Client Request");
			}

			IActionResult response = Unauthorized();
			UserModel user = AuthenticateUser(loginInfo);

			if (user != null)
			{
				var tokenString = GenerateJSONWebToken(user, "Manager");
				response = Ok(new { Token = tokenString });
			}

			return response;
		}

		private UserModel AuthenticateUser(UserModel loginInfo)
		{
			UserModel user = null;

			if (loginInfo.UserName.ToLower().Equals("test") && loginInfo.Password.Equals("test"))
			{
				user = new UserModel { UserName = "test", Password = "test" };
			}

			//user = _userRepo.GetByUserName(loginInfo.UserName.ToLower()).Result;

			//if (user != null)
			//{
			//	if (loginInfo.Password.Equals(user.Password))
			//	{
			//		return user;
			//	}
			//}

			//user = _userRepo.GetByEmail(loginInfo.Email.ToLower()).Result;

			//if (user != null)
			//{
			//	if (loginInfo.Password.Equals(user.Password))
			//	{
			//		return user;
			//	}
			//}

			return user;
		}

		private string GenerateJSONWebToken(UserModel loginInfo, string role)
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Skey"]));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, loginInfo.UserName),
				new Claim(ClaimTypes.Role, role)
			};

			var tokeOptions = new JwtSecurityToken(
				issuer: Configuration["Jwt:Issuer"],
				audience: Configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: signinCredentials
			);

			return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
		}
	}
}