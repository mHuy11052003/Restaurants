using SmartRes.Server.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartRes.Server.WebApi.Services
{
	public class UserService : IUserService
	{
		private readonly RestaurantsDbContext _context;

		public UserService(RestaurantsDbContext context)
		{
			_context = context;
		}

		public UserAccount Authenticate(string username, string password)
		{
			var user = _context.UserAccounts.SingleOrDefault(u => u.Username == username);

			if (user == null || !VerifyPassword(password, user.PasswordHash))
			{
				return null;
			}

			return user;
		}

		private bool VerifyPassword(string inputPassword, string storedPasswordHash)
		{
			return inputPassword == storedPasswordHash; // Thực tế sẽ sử dụng hashing thay vì so sánh trực tiếp
		}
	}
}
