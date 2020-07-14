using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Gimnasio
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Gimnasio")]
        public string NombreGimnasio { get; set; }

        [Display(Name = "Dirección Gimnasio")]
        public string DireccionGimnasio { get; set; }

        [Display(Name = "Localidad Gimnasio")]
        public string LocalidadGimnasio { get; set; }
        public List<Entrenador>Entrenadores { get; set; }
    }
}
