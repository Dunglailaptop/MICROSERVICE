using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using User.Service.Models;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Get IConfiguration instance
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<UsersServiceContext>(options  =>
{
       string connectionString = configuration.GetConnectionString("MySqlConnection");
       options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)));
});
var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
