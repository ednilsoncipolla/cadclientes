using CadClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadClientes.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            return View(EstadoRepository.getEstados());
        }

        public ActionResult Incluir()
        {
            return View(new Estado());
        }

        public ActionResult Novo()
        {
            return View(new Estado());
        }
        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Estado estado = new Estado()
                {
                    Est_UF = collection.GetValue("Est_UF").AttemptedValue.ToString(),
                    Est_Nome = collection.GetValue("Est_Nome").AttemptedValue.ToString(),
                };

                try
                {
                    EstadoRepository.setIncluir(estado);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            catch
            {
                return View();
            }
        }
    }
}