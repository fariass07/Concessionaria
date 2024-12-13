using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using ProjetoSistema.Models;
using ProjetoSistema.Services;
using ProjetoSistema.Services.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoSistema.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoService _motoService;

        public MotoController(MotoService motoService)
        {
            _motoService = motoService;
        }

        public async Task<IActionResult> Index()
        {
            // Obter a lista de motos do serviço
            var motos = await _motoService.FindAllAsync();

            // Passar a lista de motos para a view
            return View(motos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Moto moto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _motoService.InsertAsync(moto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não fornecido" });
            }

            var obj = await _motoService.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _motoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não fornecido" });
            }

            var obj = await _motoService.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Moto moto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id != moto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id`s não condizentes" });
            }
            try
            {
                await _motoService.UpdateAsync(moto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não fornecido" });
            }

            var obj = await _motoService.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "id não encontrado" });
            }
            return View(obj);
        }
    }
}