using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public string Localidad { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Entrenador")]
        public int? EntrenadorId { get; set; }

        public Entrenador Entrenador { get; set; }      

        public List<Ranking> Rankings { get; set; }

    }
}
