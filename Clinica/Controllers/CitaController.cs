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

            var result = server.Data_Cita_DOCTOR(id);
            List<AgregarCita> citas = new List<AgregarCita>();
            foreach (DataRow item in result.Tables[0].Rows) 
            {
                AgregarCita cita = new AgregarCita();
                // cita.Cedula = item.ItemArray.GetValue(0).ToString();
                // cita.Nombre = item.ItemArray.GetValue(1).ToString();
                // cita.Apellido1 = item.ItemArray.GetValue(2).ToString();
                // cita.Telefono = item.ItemArray.GetValue(3).ToString();
                citas.Add(cita);

            }
            return View(citas);
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
                    model.Fecha_Hora.ToLongDateString(),
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
                    model.Fecha_Hora.ToLongDateString()
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