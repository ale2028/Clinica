using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class EliminarUsuario
    {
        [Required]
        [DataType(DataType.Text)]
        public string Cedula { set; get; }
    }
}