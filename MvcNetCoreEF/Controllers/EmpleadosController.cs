using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult IncrementoSalarial()
        {
            ViewData["OFICIOS"] = this.repo.GetOficios();
            return View();
        }

        [HttpPost]
        public IActionResult IncrementoSalarial(int incremento, string oficio)
        {
            ViewData["OFICIOS"] = this.repo.GetOficios();
            ModelEmpleados model = this.repo.IncrementarSalarioOficio(incremento, oficio);
            return View(model);
        }
    }
}
