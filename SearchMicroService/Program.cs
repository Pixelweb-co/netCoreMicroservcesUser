using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Configuration;
using SearchMicroService.DataBaseSettings;
using SearchMicroService.Services;
using SearchMicroService.Models;

var builder = WebApplication.CreateBuilder(args);



//database config

builder.Services.Configure<DatabaseSettingsApp>(builder.Configuration.GetSection("UsersDatabase"));

Console.Clear();


Console.WriteLine("mostrando configuracion");

Console.WriteLine(builder.Configuration.GetSection("UsersDatabase").GetValue<String>("UsersCollectionName"));


builder.Services.AddSingleton<DatabaseSettingsApp>(d => d.GetRequiredService<IOptions<DatabaseSettingsApp>>().Value);

builder.Services.AddSingleton<UserSearchService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
