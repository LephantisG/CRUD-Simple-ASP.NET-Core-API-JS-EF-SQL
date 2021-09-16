using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudExamenContext db = new Models.CrudExamenContext())
            {
                var lista = (from p in db.PersonasSqls select p).ToList();
                return Ok(lista);
            }
        }

        [HttpPost]
        public ActionResult Post()
        {
            
        }
    }
}
