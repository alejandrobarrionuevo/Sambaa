using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.ModeloLogin
{
    [Table("Empresas")]
    public class Empresa
    {
        ILazyLoader lazyLoader;

        public Empresa(ILazyLoader lazyLoader) => this.lazyLoader = lazyLoader;

        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Esquema { get; set; }

        [InverseProperty("Empresa")]
        IEnumerable<Rol> roles;
        public IEnumerable<Rol> Roles { get => lazyLoader.Load(this, ref roles); set => roles = value; }
    }
}
