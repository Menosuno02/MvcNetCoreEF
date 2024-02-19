using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.InsertHospital(hospital);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteHospital(id);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.HospitalCod, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.NumCamas);
            return RedirectToAction("Index");
        }
    }
}
