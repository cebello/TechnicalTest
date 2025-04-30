using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.ViewModels;

namespace TechnicalTest.Controllers
{
    public class SuscriptorsController : Controller
    {
        private readonly Suscriptors funciones = new();

        public IActionResult Index()
        {
            var model = new SuscriptorsViewModel
            {
                Lista = funciones.list()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Buscar(int id)
        {
            var model = new SuscriptorsViewModel
            {
                Lista = funciones.list(),
                Resultado = funciones.find(id),
                IdBuscado = id
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            funciones.delete(id);
            var model = new SuscriptorsViewModel
            {
                Lista = funciones.list()
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Suscribirme(string nombre)
        {
            var model = new SuscriptorsViewModel
            {
                Lista = funciones.list()
            };

            if (funciones.isExist(nombre))
            {
                model.Error = "Ya existe un suscriptor con ese nombre.";
                return View("Index", model);
            }

            funciones.add(nombre);
            model.Lista = funciones.list();

            return View("Index", model);
        }
    }
}
