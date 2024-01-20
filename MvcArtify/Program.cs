using MvcArtify.DataContext;
using Microsoft.EntityFrameworkCore;
using MvcArtify.Services;
using Microsoft.AspNetCore.Authentication.Cookies; // Add this for cookie authentication

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddSingleton<FileService>();

builder.Services.AddDbContext<MvcArtifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcArtifyContext") ?? throw new InvalidOperationException("Connection string 'MvcArtifyContext' not found.")));

// Add services for authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Configure the cookie settings here if necessary
        options.LoginPath = "/Account/SignIn";
        options.LogoutPath = "/Account/SignOut";
        // Other options can be set here
    });

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserRepository>();

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

// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
