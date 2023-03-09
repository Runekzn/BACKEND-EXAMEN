using EXAMEN.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=A2RTGMQR;Database=ENCUESTA;Uid=sa;Pwd=kasan2001;Encrypt=false;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<Encuestado2> Encuestado2 { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
    }
}
