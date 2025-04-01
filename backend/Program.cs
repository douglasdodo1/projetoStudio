using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtém a string de conexão antes de construir o app
var typeDataBase = builder.Configuration["typeDataBase"] ?? throw new Exception("typeDataBase not found in configuration");
var connectionString = builder.Configuration.GetConnectionString(typeDataBase) ?? throw new Exception("Connection string not found");

builder.Services.AddDbContext<Db>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<UserValidator>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();



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
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
