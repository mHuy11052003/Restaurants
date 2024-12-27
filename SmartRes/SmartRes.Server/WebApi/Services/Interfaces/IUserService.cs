using SmartRes.Server.WebApi.Models;

namespace SmartRes.Server.WebApi.Services
{
	public interface IUserService
	{
		UserAccount Authenticate(string username, string password);
	}
}
