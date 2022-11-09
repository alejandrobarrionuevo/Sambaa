using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Modelo.Modelo;
using System.IO;

namespace Modelo.Data
{
    public class DBContextoFactory : IDesignTimeDbContextFactory<DBContexto>
    {
        public DBContexto CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json", optional: false, true)
                                            .Build();
            var options = new DbContextOptionsBuilder<DBContexto>();
            options.UseSqlServer(configuration.GetConnectionString(args[0]));

            return new DBContexto(options.Options);
        }
    }
    public class DBContexto : IDBContexto
    {
       
        public DBContexto(DbContextOptions<DBContexto> options)
           : base(options)
        {
        }

        public DBContexto(IHttpContextAccessor httpContextAccessor) : base(obtenerCadenaConexion(httpContextAccessor.HttpContext.Request.Cookies["ESQUEMA"])) {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        static DbContextOptions<DBContexto> obtenerCadenaConexion (string empresa) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                           .SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile("appsettings.json", optional: false, true)
                                           .Build();
            var options = new DbContextOptionsBuilder<DBContexto>();
            options.UseSqlServer(configuration.GetConnectionString(empresa));
            return options.Options;
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
