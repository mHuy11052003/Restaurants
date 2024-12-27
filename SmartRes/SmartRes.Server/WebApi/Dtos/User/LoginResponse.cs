namespace SmartRes.Server.WebApi.Dtos.User
{
	public class LoginResponse
	{
		public Guid UserId { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Token { get; internal set; }
	}
}
