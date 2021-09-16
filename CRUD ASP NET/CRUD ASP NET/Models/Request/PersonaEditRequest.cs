using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP_NET.Models.Request
{
    public class PersonaEditRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
    }
}
