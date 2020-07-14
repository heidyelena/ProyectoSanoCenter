using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Valoracion
    {
        public int Id { get; set; }

        [Display(Name = "Puntuación")]
        public int Puntuacion { get; set; }

        [Display(Name = "Número de Puntuaciones")]
        public int NumeroPuntuaciones { get; set; }

        [Display(Name = "Media de Puntuaciones")]
        public double MediaPuntuaciones { get; set; }

        [Display(Name = "Reto")]
        public int RetoId { get; set; }
        public Reto Reto { get; set; }
    }
}
