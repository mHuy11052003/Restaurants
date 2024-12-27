using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartRes.Server.WebApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartRes.Server.WebApi.Controllers.AuthenticationAndAuthorization;
using SmartRes.Server.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Đọc cấu hình từ appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Add services to the container.
builder.Services.AddControllers();

// Cấu hình DbContext để kết nối với cơ sở dữ liệu
builder.Services.AddDbContext<RestaurantsDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

// Cấu hình Authentication sử dụng JWT Bearer
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = jwtSettings.Issuer,
			ValidAudience = jwtSettings.Audience,
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};
	});

var app = builder.Build();

// Cấu hình middlewares
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();  // Đảm bảo dùng authentication
app.UseAuthorization();

app.MapControllers();

// Fallback cho các route chưa được định nghĩa
app.MapFallbackToFile("/index.html");

app.Run();
