using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Clinica.Models
{
    public class Doctor
    {
        [Required]
        [DataType(DataType.Text)]
        public string Cedula { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string Nombre { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string Apellido1 { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string Apellido2 { set; get; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string Especialidad { set; get; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { set; get; }

        public WsClinica.Entity_Doctor AsWebServiceModel()
        {
            WsClinica.Entity_Doctor doctor = new WsClinica.Entity_Doctor();
            doctor.apellido1 = this.Apellido1;
            doctor.apellido2 = this.Apellido2;
            doctor.cedula = this.Cedula;
            doctor.correo = this.Correo;
            doctor.especialidad = this.Especialidad;
            doctor.nombre = this.Nombre;
            doctor.password = this.Password;
            doctor.telefono = this.Telefono;
            return doctor;
        }

    }
}