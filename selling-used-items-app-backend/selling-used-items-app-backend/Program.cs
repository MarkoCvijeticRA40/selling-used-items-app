using selling_used_items_app_backend;
using selling_used_items_app_backend.Service;
using Microsoft.EntityFrameworkCore;
using selling_used_items_app_backend.Repository;
using selling_used_items_app_backend.Controllers;
using selling_used_items_app_backend.Validator.AdvertisementValidator;
using selling_used_items_app_backend.Validator.CommentValidator;
using selling_used_items_app_backend.Validator.PurchaseValidator;
using selling_used_items_app_backend.Validator.UserValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration for PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Services
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IJWTService, JWTService>();
//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
//Controllers
builder.Services.AddScoped<AdvertisementController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<CommentController>();
builder.Services.AddScoped<PurchaseController>();
//Validators
builder.Services.AddScoped<AdvertisementCreateValidator>();
builder.Services.AddScoped<AdvertisementDeleteValidator>();
builder.Services.AddScoped<AdvertisementUpdateValidator>();
builder.Services.AddScoped<CommentCreateValidator>();
builder.Services.AddScoped<CommentDeleteValidator>();
builder.Services.AddScoped<PurchaseCreateValidator>();
builder.Services.AddScoped<UserCreateValidator>();
builder.Services.AddScoped<UserDeleteValidator>();
builder.Services.AddScoped<UserUpdateValidator>();
//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "YourIssuer",
            ValidAudience = "YourAudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"))
        };
    });
//Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();