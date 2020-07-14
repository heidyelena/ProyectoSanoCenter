using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSanoCenter.Models
{
    public class Ranking
    {
        public int Id { get; set; }

        [Display(Name = "Reto")]
        public int RetoId { get; set; }
        public Reto Reto { get; set; }

        [Display(Name = "Usuario")]
        public string  UsuarioId { get; set; }
        public Usuario  Usuario { get; set; }
    }
}
