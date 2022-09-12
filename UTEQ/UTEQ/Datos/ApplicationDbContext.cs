using UTEQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UTEQ.Datos
{
    public class ApplicationDbContext: IdentityDbContext

    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Modalidad> Modalidad { get; set; }
        public DbSet<Cursos> Cursos { get; set; }

        public DbSet<UsuarioAplicacion>UsuarioAplicacion { get; set; }

        public DbSet<FormularioUsuario> FormularioUsuario { get; set; }

    }
}
