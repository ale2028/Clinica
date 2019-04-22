using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class EliminarCita
    {
        [Required]
        [DataType(DataType.Text)]
        public string IdCita { set; get; }

        [Required]
        [DataType(DataType.Text)]
        public string CedulaDoctor { set; get; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha_Hora { set; get; }
    }
}