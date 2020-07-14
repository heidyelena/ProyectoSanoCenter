using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoSanoCenter.Models;

namespace ProyectoSanoCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProyectoSanoCenter.Models.Ejercicio> Ejercicio { get; set; }
        public DbSet<ProyectoSanoCenter.Models.EjercicioReto> EjercicioReto { get; set; }
        public DbSet<ProyectoSanoCenter.Models.Entrenador> Entrenador { get; set; }
        public DbSet<ProyectoSanoCenter.Models.Gimnasio> Gimnasio { get; set; }
        public DbSet<ProyectoSanoCenter.Models.Ranking> Ranking { get; set; }
        public DbSet<ProyectoSanoCenter.Models.Reto> Reto { get; set; }
        public DbSet<ProyectoSanoCenter.Models.Valoracion> Valoracion { get; set; }
    }
}
