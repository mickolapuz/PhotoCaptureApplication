using PhotoCaptureApplication.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add connection strings.
var config = builder.Configuration;

string connectionString = config.GetSection("ConnectionStrings").GetSection("SQLServerConStr").Value.ToString();
builder.Services.AddDbContext<PhotoCaptureDataContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(config.GetSection("CORS").GetSection("AllowRequestsFrom").Get<string[]>())
            .AllowCredentials();
        }
    );
});

var app = builder.Build();

app.UseRouting();
app.UseCors("Policy");
app.UseAuthentication();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
