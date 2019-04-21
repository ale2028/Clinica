using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Cita
    {
        [Required]
        [DataType(DataType.Text)]
        public string CedulaCliente { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string CedulaDoctor { set; get; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Fecha_Hora { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string Detalle { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string IdCita { set; get; }

    }
}