using Microsoft.AspNetCore.Mvc;
using CRUDCoreMVC.Models;
using CRUDCoreMVC.Datos;

namespace CRUDCoreMVC.Controllers
{
	public class MantenedorController : Controller
	{
		ContactoDatos _ContactoDatos = new ContactoDatos();
		public IActionResult Listar()
		{
			var oLista = _ContactoDatos.Listar();
			return View(oLista);
		}

		public IActionResult Guardar()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Guardar(ContactoModel oContacto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var rpt = _ContactoDatos.Guardar(oContacto);
			if (rpt)
			{
				return RedirectToAction("listar");
			}
			else
				return View();
		}

		public IActionResult Editar(int IdContacto)
		{
			var oContacto = _ContactoDatos.Obtener(IdContacto);
			return View(oContacto);
		}

		[HttpPost]
		public IActionResult Editar(ContactoModel oContacto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var rpt = _ContactoDatos.Editar(oContacto);
			if (rpt)
			{
				return RedirectToAction("listar");
			}
			else
				return View();
		}

		public IActionResult Eliminar(int IdContacto)
		{
			var oContacto = _ContactoDatos.Obtener(IdContacto);
			return View(oContacto);
		}

		[HttpPost]
		public IActionResult Eliminar(ContactoModel oContacto)
		{
			var rpt = _ContactoDatos.Eliminar(oContacto.IdContacto);
			if (rpt)
			{
				return RedirectToAction("listar");
			}
			else
				return View();
		}
	}
}
