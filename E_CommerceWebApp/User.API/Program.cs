using Microsoft.EntityFrameworkCore;
using User.API.Data.DbContexts;
using User.API.Models;
using User.API.Repositories;
using User.API.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseInMemoryDatabase("UserInMemoryDb"); // Use in-memory database
});
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // Ensure the app listens on port 80
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Ensure database is created and seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    context.Database.EnsureCreated();

    // Seed data if necessary
    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new UserModel { UserId = 1, UserName = "ankul", Email = "ankul@gmail.com", Password = "ankul123" },
            new UserModel { UserId = 2, UserName = "admin", Email = "nikhil@gmail.com", Password = "ankul123" },
            new UserModel { UserId = 3, UserName = "admin", Email = "admin@gmail.com", Password = "admin123" }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Enable CORS
app.UseCors("AllowAll");

app.MapGet("/", () => "User API API is running.");

app.MapControllers();

app.Run();
