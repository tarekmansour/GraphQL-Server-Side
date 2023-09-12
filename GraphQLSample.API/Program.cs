using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.Interface;
using GraphQLSample.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("main")));

builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();