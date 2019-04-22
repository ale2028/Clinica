using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index(String id)
        {
            // Llamamos al servicio web para eliminar un usuario
            WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

            var result = server.Consulta_Doctores();
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
        public ActionResult AgregarCita()
        {
            AgregarCita model = new AgregarCita();
            model.IdCita = Guid.NewGuid().ToString();
            return View(model);
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult AgregarCita(AgregarCita model)
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
                return RedirectToAction("Index", "Home");
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
        public ActionResult CancelarCita(EliminarCita model)
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