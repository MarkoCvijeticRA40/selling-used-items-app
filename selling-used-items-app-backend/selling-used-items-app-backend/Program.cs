using selling_used_items_app_backend.Data;
using selling_used_items_app_backend.Service;
using Microsoft.EntityFrameworkCore;
using selling_used_items_app_backend.Repository;
using selling_used_items_app_backend.Controllers;
using selling_used_items_app_backend.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration for PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AdvertisementService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

builder.Services.AddScoped<AdvertisementController>();
builder.Services.AddScoped<UserController>();

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