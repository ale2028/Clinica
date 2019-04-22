using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index(string id)
        {
            return View(); 
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
        public ActionResult Register(Usuario model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para registrar un nuevo usuario
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                string result = server.Registrar_Usuario
                    (
                    model.Cedula,
                    model.Nombre,
                    model.Apellido1,
                    model.Apellido2,
                    model.Correo,
                    model.Password,
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
        public ActionResult EliminarUsuario()
        {
            return View();
        }

        /// <summary>
        /// Recibe los datos de la vista
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>s
        [HttpPost]
        public ActionResult EliminarUsuario(EliminarUsuario model)
        {
            if (ModelState.IsValid)
            {
                // Llamamos al servicio web para eliminar un usuario
                WsClinica.WS_SERVER server = new WsClinica.WS_SERVER();

                bool result = server.Remover_Usuario (model.Cedula);
                

                Console.WriteLine(result);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Datos erroneos", "El usuario no fue encontrado");
            }
            return View(model);
        }

    }
}