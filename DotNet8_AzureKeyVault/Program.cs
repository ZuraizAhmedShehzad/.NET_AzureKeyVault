using Azure.Identity;
using DotNet8_AzureKeyVault.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var azureKeyVaultSettings = new AzureKeyVaultSettings();
builder.Configuration.GetSection("AzureKeyVault").Bind(azureKeyVaultSettings);

var clientSecretCredential = new ClientSecretCredential(
    azureKeyVaultSettings.TenantId,
    azureKeyVaultSettings.ClientId,
    azureKeyVaultSettings.ClientSecret
);

builder.Configuration.AddAzureKeyVault(new Uri(azureKeyVaultSettings.VaultUrl), clientSecretCredential);

var connectionString = builder.Configuration["ConnString"];


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
