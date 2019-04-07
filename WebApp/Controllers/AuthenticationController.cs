using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationSettings _applicationSettings;

		public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> applicationSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_applicationSettings = applicationSettings.Value;

		}

		[HttpPost]
		[Route("Register")]
		//POST : /api/Authentication/Register
		public async Task<object> PostApplicationUser(ApplicationUserModel model)
		{
			var applicationUser = new ApplicationUser()
			{
				UserName = model.UserName,
				Email = model.Email,
				CompanyName = model.CompanyName
			};

			try 
			{
				var result = await _userManager.CreateAsync(applicationUser, model.Password);
				return Ok(result);
			}
			catch (global::System.Exception ex)
			{

				throw ex;
			}
		}

		//POST : /api/Authentication/Login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
			{
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim("UserID",user.Id.ToString()),

					}),
					Expires = DateTime.Now.AddMinutes(Double.Parse((_applicationSettings.Token_Expire_Time))),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_secret)),SecurityAlgorithms.HmacSha256)
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
				var token = tokenHandler.WriteToken(securityToken);
				return Ok(new { token });

			}
			else
				return BadRequest(new { message = "Username or Password is incorrect" });
		}
	}
}