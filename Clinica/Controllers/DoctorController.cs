using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class DoctorController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();
            var result = server.;
            List<WsClinica.Entity_User> users = new List<WsClinica.Entity_User>();
            return View(users);
        }

        /// <summary>
        /// M<uestra la vista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult Register(Doctor model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para registrar un nuevo doctor
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();
                string result = server.Registrar_Doctor(model.AsWebServiceModel());
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