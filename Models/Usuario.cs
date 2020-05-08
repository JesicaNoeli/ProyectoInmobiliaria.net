using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class Usuario
    {
        [Key]
        public int IdUs { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
         public string Email { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }

    }
}
