using MvcArtify.DataContext;
using Microsoft.EntityFrameworkCore;
using MvcArtify.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddSingleton<FileService>();
builder.Services.AddDbContext<MvcArtifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcArtifyContext") ?? throw new InvalidOperationException("Connection string 'MvcArtifyContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //Only seed when no data exits in db
    //SeedData.Initialize(services);
}

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
