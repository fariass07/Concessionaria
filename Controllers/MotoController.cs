using Microsoft.AspNetCore.Mvc;
using ProjetoSistema.Services;

namespace ProjetoSistema.Controllers
{
    public class MotoController(MotoService service) : Controller
    {
        private readonly MotoService _service = service;

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        /*public IActionResult Create()
        {
            criar Create
        }*/
    }
}
