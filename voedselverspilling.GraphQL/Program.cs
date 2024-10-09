using voedselverspilling.DomainServices;
using voedselverspilling.GraphQL.Queries;
using voedselverspilling.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ICanteenRepository, CanteenRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddDbContext<voedselverspillingDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Voedselverspilling")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>();


var app = builder.Build();

app.MapGraphQL();

app.Run();
