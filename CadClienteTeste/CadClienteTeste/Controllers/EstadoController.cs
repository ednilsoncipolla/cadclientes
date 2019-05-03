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
        public ActionResult Novo(FormCollection collection)
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
                catch (Exception)
                {
                    throw;
                }

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Alterar(string est_UF)
        {
            return View(EstadoRepository.getEstado(est_UF));
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Alterar(FormCollection collection)
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
                    EstadoRepository.setAlterar(estado);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Excluir(string est_UF)
        {
            return View(EstadoRepository.getEstado(est_UF));
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Excluir(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Estado estado = new Estado()
                {
                    Est_UF = collection.GetValue("Est_UF").AttemptedValue.ToString(),
                };

                try
                {
                    EstadoRepository.setExcluir(estado);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Detalhes(string est_UF)
        {
            return View(EstadoRepository.getEstado(est_UF));

        }
    }
}