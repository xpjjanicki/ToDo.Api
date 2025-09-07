using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Core.Interfaces;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
