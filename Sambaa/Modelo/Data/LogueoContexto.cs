using Microsoft.EntityFrameworkCore;
using Modelo.ModeloLogin;

namespace Modelo.Data
{
    public class LogueoContexto : DbContext
    {
        public LogueoContexto(DbContextOptions<LogueoContexto> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

    }
}
