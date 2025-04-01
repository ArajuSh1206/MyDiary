using Microsoft.EntityFrameworkCore;
using MyDiary.Data;

var builder = WebApplication.CreateBuilder(args);

// Fetch the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Replace the placeholder `{DB_PASSWORD}` with the actual environment variable
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

if (string.IsNullOrEmpty(dbPassword))
{
    throw new InvalidOperationException("DB_PASSWORD environment variable is not set.");
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
