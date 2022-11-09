using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.ModeloLogin
{
    [Table("UsuariosRoles")]
    public class UsuarioRol
    {
        readonly ILazyLoader lazyLoader;

        public UsuarioRol(ILazyLoader lazyLoader) => this.lazyLoader = lazyLoader;

        public Guid UsuarioId { get; set; }
        public int RolId { get; set; }


        Usuario usuario;
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get => lazyLoader.Load(this, ref usuario); set => usuario = value; }
        Rol rol;
        [ForeignKey("RolId")]
        public Rol Rol { get => lazyLoader.Load(this, ref rol); set => rol = value; }
    }

    public class UsuarioRolFluentMap : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.HasKey(ure => new { ure.UsuarioId, ure.RolId});
        }
    }
}