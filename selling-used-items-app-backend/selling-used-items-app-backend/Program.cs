using Microsoft.IdentityModel.Tokens;
using selling_used_items_app_backend;
using selling_used_items_app_backend.Service;
using System.Text;
using Microsoft.EntityFrameworkCore;
using selling_used_items_app_backend.Repository;
using selling_used_items_app_backend.Controllers;
using selling_used_items_app_backend.Validator.AdvertisementValidator;
using selling_used_items_app_backend.Validator.CommentValidator;
using selling_used_items_app_backend.Validator.PurchaseValidator;
using selling_used_items_app_backend.Validator.UserValidator;
using selling_used_items_app_backend.Validator.ReportValidator;
using selling_used_items_app_backend.Validator.MessageValidator;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration for PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
// Services
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IMessageService, MessageService>();
// Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
// Controllers
builder.Services.AddScoped<AdvertisementController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<CommentController>();
builder.Services.AddScoped<PurchaseController>();
builder.Services.AddScoped<ReportController>();
builder.Services.AddScoped<MessageController>();
// Validators
builder.Services.AddScoped<AdvertisementCreateValidator>();
builder.Services.AddScoped<AdvertisementDeleteValidator>();
builder.Services.AddScoped<AdvertisementUpdateValidator>();
builder.Services.AddScoped<CommentCreateValidator>();
builder.Services.AddScoped<CommentDeleteValidator>();
builder.Services.AddScoped<PurchaseCreateValidator>();
builder.Services.AddScoped<UserCreateValidator>();
builder.Services.AddScoped<UserDeleteValidator>();
builder.Services.AddScoped<UserUpdateValidator>();
builder.Services.AddScoped<ReportCreateValidator>();
builder.Services.AddScoped<MessageCreateValidator>();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();