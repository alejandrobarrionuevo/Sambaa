using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Modelo
{
    [Table("Personas")]
    public class Persona
    {
        readonly ILazyLoader lazyLoader;
        public Persona(ILazyLoader lazyLoader) => this.lazyLoader = lazyLoader;
        public int TipoDocumentoId { get; set; }
        public long NumeroDocumento { get; set; }
        public string Nombre { get; set; }

        TipoDocumento tipoDocumento;
        [ForeignKey("TipoDocumentoId")]
        internal TipoDocumento TipoDocumento { get => lazyLoader.Load(this, ref tipoDocumento); set => tipoDocumento = value; }
        protected ILazyLoader GetLazyLoader() => this.lazyLoader;
    }


    public class PersonaFluentMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(persona => new { persona.TipoDocumentoId, persona.NumeroDocumento }); 
        }
    }
}
