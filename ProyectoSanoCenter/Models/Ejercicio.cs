using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Ejercicio")]
        public string NombreEjercicio { get; set; }

        [Display(Name = "Demostración")]
        public string Demostracion { get; set; }
        public List<EjercicioReto>EjercicioRetos { get; set; }       
    }
}
