using GraphQL;
using GraphQL.Server.Ui.GraphiQL;

using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.GraphQL;
using GraphQLSample.API.Interface;
using GraphQLSample.API.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container
services.AddDbContext<ApplicationContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("main")));

//GraphQL
services.AddSingleton<AppQuery>();
services.AddScoped<ISellerRepository, SellerRepository>();
services.AddScoped<IVehicleRepository, VehicleRepository>();

services.AddGraphQL(builder => {
    builder.AddSchema<AppSchema>();
    builder.AddGraphTypes(typeof(AppQuery).Assembly);
    builder.AddSystemTextJson(opt =>
    {
        opt.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        opt.WriteIndented = false;
    });
    builder.AddErrorInfoProvider(opt => {
        // hide exception details to callers
        opt.ExposeExtensions = false;
        opt.ExposeExceptionDetails = false;
    });
    builder.ConfigureExecutionOptions(opt => {
        var logger = opt.RequestServices?.GetService<ILogger<AppQuery>>() ?? (ILogger)NullLogger.Instance;

        opt.UnhandledExceptionDelegate = ctx => {
            if (ctx.Context is null)
            {
                // configuration/schema error
                logger.LogError(ctx.OriginalException, "Unexpected error in GraphQL configuration.");
            }
            else
            {
                // execution error
                logger.LogError(
                    ctx.OriginalException,
                    "Unexpected error executing GraphQL query '{query}'.",
                    ctx.FieldContext is not null
                        ? ctx.FieldContext.Document.Source[ctx.FieldContext.FieldAst.Location.Start..ctx.FieldContext.FieldAst.Location.End]
                        : ctx.Context.Document.Source);
            }

            ctx.ErrorMessage = $"An unexpected error occured resolving field '{ctx.FieldContext?.FieldAst?.Alias?.Name?.StringValue ?? ctx.FieldContext?.FieldAst?.Name?.StringValue}'. (Request ID: {Activity.Current?.Id})";

            return Task.CompletedTask;
        };
    });
});

services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("graphql");

if (app.Environment.IsDevelopment())
{
    // add GraphiQL for development
    app.MapGraphQLGraphiQL(options: new GraphiQLOptions());
}

app.Run();