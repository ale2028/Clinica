using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// M<uestra la vista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AgregarCita()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult AgregarCita(Cita model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para agendar una cita 
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Agendar_Cita
                    (
                    model.CedulaCliente,
                    model.CedulaDoctor,
                    model.Fecha_Hora,
                    model.Detalle
                    );


                Console.WriteLine(result);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Faltan datos", "No todos los datos requeridos, están presentes");
            }
            return View(model);
        }

        /// <summary>
        /// M<uestra la vista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CancelarCita()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult CancelarCita(Cita model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para cancelar una cita 
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Remover_Cita
                    (
                    model.IdCita,
                    model.CedulaDoctor,
                    model.Fecha_Hora
                    );


                Console.WriteLine(result);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Faltan datos", "No todos los datos requeridos, están presentes");
            }
            return View(model);
        }

    }
}