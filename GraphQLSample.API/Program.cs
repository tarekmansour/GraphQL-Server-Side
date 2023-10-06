using GraphQL.Server;
using GraphQL.Types;
using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.GraphQL;
using GraphQLSample.API.Interface;
using GraphQLSample.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container
services.AddDbContext<ApplicationContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("main")));

services.AddScoped<ISellerRepository, SellerRepository>();
services.AddScoped<IVehicleRepository, VehicleRepository>();

//GraphQL
services.AddScoped<AppSchema>();

services.AddGraphQL(builder => builder );

services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();