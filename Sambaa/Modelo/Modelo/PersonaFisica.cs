using Microsoft.EntityFrameworkCore.Infrastructure;
using Modelo.ModeloLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Modelo
{
    public class PersonaFisica : Persona
    {        
        public PersonaFisica(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public string Apellido { get; set; }
        public Guid UsuarioId { get; set; }
        Usuario usuario;
        public Usuario Usuario { get => GetLazyLoader().Load(this, ref usuario); set => usuario = value; }
    }
}
