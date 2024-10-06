using Microsoft.AspNetCore.Mvc;
using CRUD.WebApp.Data;
using CRUD.WebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUD.WebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
