using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Aplicaciones.Servicios;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.API.Controllers;
using AppFinanciero.Infraestructura.API.Interfaces;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region "Cors"

var misReglasCors = "corsapp";

builder.Services.AddCors(p => p.AddPolicy(misReglasCors, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

#region "Inyección de dependencias"

//Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("Financiero");
builder.Services.AddDbContext<FinancieroContexto>(x =>
{
    x.UseSqlServer(connectionString);
    x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<FinancieroContexto>();

//Inyección para los repositorios
builder.Services.AddTransient<IRepositorioBase<ClienteDominio, int>, ClienteRepositorio>();
builder.Services.AddTransient<IRepositorioBaseActualizar<ProductoDominio, int>, ProductoRepositorio>();
builder.Services.AddTransient<IRepositorioBase<ProductoEstadoDominio, int>, ProductoEstadoRepositorio>();
builder.Services.AddTransient<IRepositorioBase<TipoProductoDominio, int>, TipoProductoRepositorio>();
builder.Services.AddTransient<IRepositorioBase<TipoTransaccionDominio, int>, TipoTransaccionRepositorio>();
builder.Services.AddTransient<IRepositorioTransaccion<TransaccionDominio, int>, TransaccionRepositorio>();
builder.Services.AddTransient<IRepositorioAutenticacion<AutenticacionDominio, string>, AutenticacionRepositorio>();

//Inyección para los servicios
builder.Services.AddTransient<IServicioBase<ClienteDominio, int>, ClienteServicio>();
builder.Services.AddTransient<IServicioBaseActualizar<ProductoDominio, int>, ProductoServicio>();
builder.Services.AddTransient<IServicioBase<ProductoEstadoDominio, int>, ProductoEstadoServicio>();
builder.Services.AddTransient<IServicioBase<TipoProductoDominio, int>, TipoProductoServicio>();
builder.Services.AddTransient<IServicioBase<TipoTransaccionDominio, int>, TipoTransaccionServicio>();
builder.Services.AddTransient<IServicioTransaccion<TransaccionDominio, int>, TransaccionServicio>();
builder.Services.AddTransient<IServicioAutenticacion<AutenticacionDominio, string>, AutenticacionServicio>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(misReglasCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
