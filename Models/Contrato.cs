using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class Contrato
    {
        [Key]
        public int IdContr { get; set; }
        public int IdInq { get; set; }
        public Inquilino Inquilino { get; set; }
        public int IdInm { get; set; }
        public Inmueble Inmueble { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public decimal Monto { get; set; }
        public bool Vigente { get; set; }

    }
}
