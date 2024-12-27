using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartRes.Server.WebApi.Models;
using SmartRes.Server.WebApi.Dtos.User;
using SmartRes.Server.WebApi.Services; // Thêm namespace cho IUserService
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SmartRes.Server.WebApi.Controllers.AuthenticationAndAuthorization;

namespace SmartRes.Server.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly JwtSettings _jwtSettings;
		private readonly IUserService _userService;  // Thêm IUserService vào constructor

		public AuthController(IOptions<JwtSettings> jwtSettings, IUserService userService)
		{
			_jwtSettings = jwtSettings.Value;
			_userService = userService;  // Khởi tạo IUserService
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest1 loginRequest)
		{
			// Kiểm tra thông tin người dùng, lấy thông tin từ DB qua IUserService
			var user = _userService.Authenticate(loginRequest.Username, loginRequest.Password);

			if (user == null)
			{
				return Unauthorized(new { message = "Invalid username or password" });
			}

			// Tạo thông tin Claims
			var claims = new[]
			{
		new Claim(ClaimTypes.Name, user.Username),
		new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
	};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(180),
				signingCredentials: creds
			);

			// Trả về thêm thông tin chi tiết về người dùng
			return Ok(new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token),
				username = user.Username,
				email = user.Email,  // Thêm email
				profilePicture = user.ProfilePicture,  // Thêm hình đại diện
				expiration = DateTime.Now.AddMinutes(180)
			});
		}
	}
}
