using Microsoft.EntityFrameworkCore;
using MyDiary.Data;
using DotNetEnv; // Import DotNetEnv to load .env variables

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env
Env.Load();

// Fetch the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Get DB_PASSWORD from the environment
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

if (string.IsNullOrEmpty(dbPassword))
{
    throw new InvalidOperationException("DB_PASSWORD environment variable is not set.");
}

// Replace `{DB_PASSWORD}` in the connection string
connectionString = connectionString.Replace("{DB_PASSWORD}", dbPassword);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=MyPage}/{id?}");

app.Run();
