using Estudiopi_dotnet.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;
using Profesionpi_dotnet.Models.Repository;
using Telefonopi_dotnet.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDBContext"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<ITelefonoRepository, TelefonoRepository>();
builder.Services.AddTransient<IProfesionRepository, ProfesionRepository>();
builder.Services.AddTransient<IEstudioRepository, EstudioRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
