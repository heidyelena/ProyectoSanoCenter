using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Reto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string NombreReto { get; set; }
        public string Dificultad { get; set; }
        public string Series { get; set; }
        public string Repeticiones { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Límite")]
        public DateTime FechaLimite{ get; set; }

        [Display(Name = "Entrenador")]
        public int EntrenadorId { get; set; }
        public Entrenador Entrenador { get; set; }
        public List<EjercicioReto>EjercicioRetos { get; set; }
        public List<Ranking>Rankings { get; set; }
        public List<Valoracion> Valoraciones { get; set; }

    }
}
