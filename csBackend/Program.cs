using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database is created and migrated
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Ensure the database is created
    dbContext.Database.Migrate(); // Apply any pending migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// This code will run when the application starts
// Log data from the database in the console
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Retrieve all teachers from the database
    var teachers = dbContext.Teachers.ToList();

    // Log each teacher's data in the console
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"Teacher ID: {teacher.TeacherId}, Name: {teacher.FirstName} {teacher.LastName}, Date of Birth: {teacher.DateOfBirth}");
    }
}

app.Run();
