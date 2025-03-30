using AnchorPage.API.Core;
using AnchorPage.Application.Commands;
using AnchorPage.Application.Queries;
using AnchorPage.DataAccess;
using AnchorPage.Implementation.Commands;
using AnchorPage.Implementation.Queries;
using AnchorPage.Implementation.Validation;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

//Binding data from configuration file to an instance of appSettings class
//var appSettings = new AppSettings();
//builder.Configuration.Bind(appSettings);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();



// Configure the HTTP request pipeline.
if (builder.Environment.IsProduction())
{
    var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
    var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
    var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
    var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

    var credential = new ClientSecretCredential(keyVaultDirectoryId.Value!.ToString(), 
        keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString());

    builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!.ToString(), keyVaultClientId.Value!.ToString(),
        keyVaultClientSecret.Value!.ToString(), new DefaultKeyVaultSecretManager());

    var client = new SecretClient(new Uri(keyVaultURL.Value!.ToString()), credential);

    builder.Services.AddDbContext<AnchorPageContext>(options =>
        options.UseSqlServer(client.GetSecret("ConnectionString").Value.Value.ToString()));
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





var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
