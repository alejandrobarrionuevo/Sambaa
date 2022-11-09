using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Modelo;

namespace Modelo.ModeloLogin
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        [InverseProperty("Usuario")]
        public IEnumerable<UsuarioRol> RolesEmpresas { get; set; }
    }
}
