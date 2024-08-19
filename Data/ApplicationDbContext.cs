using Microsoft.EntityFrameworkCore;
using Examen2.Models; 
using Examen2.Data; 

namespace Examen2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
