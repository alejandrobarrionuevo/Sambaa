using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.ModeloLogin
{
    [Table("RolesEmpresas")]
    public class Rol
    {
        readonly ILazyLoader lazyLoader;

        public Rol(ILazyLoader lazyLoader) => this.lazyLoader = lazyLoader;

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Guid EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        Empresa empresa;
        public Empresa Empresa { get => lazyLoader.Load(this, ref empresa); set => empresa = value; }
    }
}