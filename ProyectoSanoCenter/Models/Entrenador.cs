using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string Foto { get; set; }

        [Display(Name = "Nombre Entrenador")]
        public string NombreEntrenador { get; set; }

        [Display(Name = "Apellidos Entrenador")]
        public string ApellidoEntrenador { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Especialidad { get; set; }

        [Display(Name = "Gimnasio")]
        public int GimnasioId { get; set; }

        public Gimnasio Gimnasio { get; set; }
        public List<Usuario>Usuarios{ get; set; }
        public List<Reto>Retos{ get; set; }
    }
}
