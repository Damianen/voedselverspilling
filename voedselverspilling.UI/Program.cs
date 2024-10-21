using voedselverspilling.DomainServices;
using voedselverspilling.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ICanteenRepository, CanteenRepository>();
builder.Services.AddScoped<IResorvationRepository, ResorvationRepository>();

builder.Services.AddDbContext<voedselverspillingDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Voedselverspilling")));

builder.Services.AddDbContext<IdentityDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Identity")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
