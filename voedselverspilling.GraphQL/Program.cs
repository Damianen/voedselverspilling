using voedselverspilling.DomainServices;
using voedselverspilling.GraphQL.Mutation;
using voedselverspilling.GraphQL.Queries;
using voedselverspilling.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPackageRepository, PackageRepository>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<voedselverspillingDBContext>(options => options.UseNpgsql(connectionString));

builder.Services
    .AddGraphQL()
    .RegisterService<IPackageRepository>()
    .AddMutationType<Mutation>()
    .AddQueryType<PackageQueries>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
