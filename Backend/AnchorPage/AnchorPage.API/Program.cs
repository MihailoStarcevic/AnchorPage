using AnchorPage.API.Core;
using AnchorPage.Application.Commands;
using AnchorPage.Application.Queries;
using AnchorPage.DataAccess;
using AnchorPage.Implementation.Commands;
using AnchorPage.Implementation.Queries;
using AnchorPage.Implementation.Validation;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.Reflection.Metadata.Ecma335;
using Swashbuckle.AspNetCore.SwaggerGen;
using AnchorPage.Application;
using AnchorPage.Implementation.Logging;

var builder = WebApplication.CreateBuilder(args);

//Binding data from configuration file to an instance of appSettings class
//var appSettings = new AppSettings();
//builder.Configuration.Bind(appSettings);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure the HTTP request pipeline.
if (builder.Environment.IsProduction())
{
    var keyVaultURL = builder.Configuration.GetValue<string>("KeyVault:KeyVaultURL");

    if (string.IsNullOrEmpty(keyVaultURL))
    {
        throw new Exception("KeyVault URL is not configured or is empty!");
    }

    // Initialize SecretClient to fetch secrets from Key Vault
    var client = new SecretClient(new Uri(keyVaultURL), new DefaultAzureCredential());

    try
    {
        // Retrieve the connection string from Key Vault
        var secret = client.GetSecret("ConnectionString");
        var connectionString = secret.Value.Value;

        // Check if the connection string is null or empty
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Database connection string is missing or empty in Key Vault!");
        }

        // Configure DbContext with the retrieved connection string
        builder.Services.AddDbContext<AnchorPageContext>(options =>
            options.UseSqlServer(connectionString));
    }
    catch (Exception ex)
    {
        // Handle any errors retrieving the secret or configuring DbContext
        throw new Exception("Failed to retrieve connection string from Key Vault.", ex);
    }
}

if (builder.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    var test = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<AnchorPageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

//Dependency Injection

builder.Services.AddTransient<IGetRolesQuery, GetRolesQuery>();
builder.Services.AddTransient<ICreateRoleCommand, CreateRoleCommand>();
builder.Services.AddTransient<IDeleteRoleCommand, DeleteRoleCommand>();
builder.Services.AddTransient<IUpdateRoleCommand, UpdateRoleCommand>();
builder.Services.AddTransient<CreateRoleValidator>();
builder.Services.AddTransient<UpdateRoleValidator>();

builder.Services.AddTransient<IApplicationActor, FakeApiActor>();
builder.Services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
builder.Services.AddTransient<UseCaseExecutor>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
