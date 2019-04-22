using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginUsuario
        public ActionResult Index()
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
        public ActionResult LoginUsuario()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult LoginUsuario(LoginUsuario model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para ingresar a la cuenta del usuario
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Login_Usuario
                    (
                    model.Cedula,
                    model.Password
                    );


                Console.WriteLine(result);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Datos erroneos", "El usuario no fue encontrado");
            }
            return View(model);
        }

        /// <summary>
        /// M<uestra la vista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoginDoctor()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult LoginDoctor(LoginDoctor model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para ingresar a la cuenta del doctor 
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Login_Doctor
                    (
                    model.Cedula,
                    model.Password
                    );


                Console.WriteLine(result);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Datos erroneos", "El usuario no fue encontrado");
            }
            return View(model);
        }
    }
}