using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var typeDataBase = builder.Configuration["typeDataBase"] ?? throw new Exception("typeDataBase not found in configuration");
var connectionString = builder.Configuration.GetConnectionString(typeDataBase) ?? throw new Exception("Connection string not found");

builder.Services.AddDbContext<Db>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<UserValidator>();
builder.Services.AddScoped<SessionValidator>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AddressController>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressUserController>();
builder.Services.AddScoped<AddressUserService>();
builder.Services.AddScoped<AddressUserRepository>();
builder.Services.AddScoped<NeighborhoodController>();
builder.Services.AddScoped<NeighborhoodService>();
builder.Services.AddScoped<NeighborhoodRepository>();
builder.Services.AddScoped<ServiceController>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<ServiceSessionController>();
builder.Services.AddScoped<ServiceSessionService>();
builder.Services.AddScoped<ServiceSessionRepository>();
builder.Services.AddScoped<SessionController>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<SessionRepository>();
builder.Services.AddScoped<StreetController>();
builder.Services.AddScoped<StreetService>();
builder.Services.AddScoped<StreetRepository>();
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SessionValidator>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
