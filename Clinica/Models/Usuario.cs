using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Usuario
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
        [DataType(DataType.PhoneNumber)]
        public string Telefono { set; get; }

    }
}