using Microsoft.AspNetCore.Mvc;
using Pet_World.Models; // Asegúrate de tener el modelo de usuario
using Pet_World.Models.Entity;
using System.Threading.Tasks;

public class RegistroController : Controller
{
    private readonly ApplicationDbContext _context;

    public RegistroController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Cargar la vista de registro
    public IActionResult getRegistro()
    {
        return View("Registro");
    }

    // Procesar el formulario de registro
    [HttpPost]
    public async Task<IActionResult> Index(UserModel user)
    {
        if (ModelState.IsValid)
        {
           // _context.Users.Add(user); // Guardar el usuario en la base de datos
            //await _context.SaveChangesAsync();
            //return RedirectToAction("Index", "Home"); // Redirigir a la página de inicio
        }
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            return View(usuario); // Vuelve a mostrar la vista con errores de validación
        }

        _context.usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Registro exitoso. Ahora puedes iniciar sesión.";

        return RedirectToAction("Login", "Account"); // Redirige a la página de login
    }
}
