using System;
using System.Collections.Generic;
using System.Data;
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
            // Llamamos al servicio web para eliminar un usuario
            WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

            var result = server.Data_DOCTORES();
            List<Doctor> doctores = new List<Doctor>();
            foreach (DataRow item in result.Tables[0].Rows)
            {
                Doctor doc = new Doctor();
                doc.Cedula = item.ItemArray.GetValue(0).ToString();
                doc.Nombre = item.ItemArray.GetValue(1).ToString();
                doc.Apellido1 = item.ItemArray.GetValue(2).ToString();
                doc.Telefono = item.ItemArray.GetValue(3).ToString();
                doctores.Add(doc);

            }
            return View(doctores);
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
        public ActionResult EliminarDoctor(String id)
        {
            WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();
            bool result = server.Remover_Doctor(id);
            return RedirectToAction("Index", "Doctor");
        }

    }
}