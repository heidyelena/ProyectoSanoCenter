using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class EjercicioReto
    {
        public int Id { get; set; }

        [Display(Name = "Reto")]
        public int RetoId { get; set; }
        public Reto Reto { get; set; }

        [Display(Name = "Ejercicio")]
        public int EjercicioId { get; set; }
        public Ejercicio Ejercicio { get; set; }
    }
}
