using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CRUD_ASP_NET.Models
{
    public partial class PersonasSql
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Puntos { get; set; }
    }
}
