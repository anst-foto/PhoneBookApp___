using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PhoneBookApp.Model;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") 
                       ?? throw new InvalidOperationException("Connection string is empty");
var db = new DbContext(connectionString);

builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();

app.MapGet("/", () => Results.BadRequest());
app.MapGet("/persons", async () =>
{
    var persons = await db.GetPersons();
    return Results.Ok(persons);
});
app.MapPost("/persons", async ([FromBody] Person person) =>
{
    var result = await db.AddPerson(person);
    return result 
        ? Results.Created() 
        : Results.BadRequest();
});

await app.RunAsync();
