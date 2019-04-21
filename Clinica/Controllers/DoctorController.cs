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
            var doctores = server.Data_DOCTORES().Tables;
            Console.WriteLine(doctores[0]);

            return View(new List<Doctor>());
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

                string result = server.Registrar_Doctor
                    (
                    model.Cedula, 
                    model.Nombre,
                    model.Apellido1, 
                    model.Apellido2, 
                    model.Correo,
                    model.Password, 
                    model.Especialidad, 
                    model.Telefono
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
        public ActionResult EliminarDoctor()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult EliminarDoctor(Doctor model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para eliminar un doctor
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Remover_Doctor (model.Cedula);


                Console.WriteLine(result);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Datos erroneos", "El doctor no fue encontrado");
            }
            return View(model);
        }

    }
}