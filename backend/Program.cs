using Microsoft.EntityFrameworkCore;
using TaskTrackrAPI.Data;
using TaskTrackrAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core + PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("AllowAll", p =>
    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

// Ensure database and tables are created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
