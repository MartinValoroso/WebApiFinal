using Microsoft.EntityFrameworkCore;//Agregar
using SWProvincias_Valoroso.Models;//agregar

namespace SWProvincias_Valoroso.Data
{
    public class DbPaisFinalContext : DbContext
    {
        public DbPaisFinalContext(DbContextOptions<DbPaisFinalContext> options) : base(options) { }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Provincia> Provincias { get; set;}
    }
}
