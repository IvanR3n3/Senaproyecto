namespace Pet_World.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Pet_World.Models;

    public class AccountController : Controller
    {

        public readonly ApplicationDbContext applicationDbContext;

        public AccountController (ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public IActionResult getLogin()
        {
            return View("Login");
        }

        public IActionResult getInicio()
        {
            return View("Inicio");
        }

        public async Task<IActionResult> Login(string Email, string Password)
        {
            var usuarioEncontrado = await applicationDbContext.usuarios.FirstOrDefaultAsync( u  => u.Email == Email  && u.Password == Password);

            if (usuarioEncontrado != null)
            {
                // 🔹 Obtener los pacientes asociados al dueño
                //var pacientes = await DuenoRepository.GetPacientesByDuenoId(usuarioEncontrado.Id);

                // 🔹 Pasar la lista de pacientes a la vista
                //return RedirectToAction("GetDashboardWithId", "BashBoard", new { duenoId = usuarioEncontrado.Id });

                return View("Inicio");

            }

            ViewData["Error"] = "Usuario o contraseña incorrectos";
            return View();
        }
    }
    

}

