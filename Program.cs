using Microsoft.EntityFrameworkCore;

using Pet_World.Models;


var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue24331", true);

// Configuración de Entity Framework con MariaDB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);


// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Ruta principal
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registro}/{action=getRegistro}/{id?}");


app.Run();
