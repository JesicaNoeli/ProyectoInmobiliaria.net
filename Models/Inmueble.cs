using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class Inmueble
    {
        [Key]
        public int IdInm { get; set; }
        public int IdProp { get; set; }
        public Propietario Propietario { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public string  Uso{ get; set; }
        public int CantAmbientes { get; set; }
        public decimal Costo { get; set; }
        public bool Disponible { get; set; }
    }
}
