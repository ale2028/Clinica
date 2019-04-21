using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class LoginDoctor
    {
        [Required]
        [DataType(DataType.Text)]
        public string Cedula { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}