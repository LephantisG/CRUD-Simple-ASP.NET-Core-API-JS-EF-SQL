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
        public ActionResult Post([FromBody] Models.Request.PersonaRequest modelPersona)
        {
            using (Models.CrudExamenContext db = new Models.CrudExamenContext())
            {
                Models.PersonasSql oPersonasSql = new Models.PersonasSql();
                oPersonasSql.Nombre = modelPersona.Nombre;
                oPersonasSql.Puntos = modelPersona.Puntos;
                db.PersonasSqls.Add(oPersonasSql);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.PersonaEditRequest modelPersona)
        {
            using (Models.CrudExamenContext db = new Models.CrudExamenContext())
            {
                Models.PersonasSql oPersonasSql = db.PersonasSqls.Find(modelPersona.Id);
                oPersonasSql.Nombre = modelPersona.Nombre;
                oPersonasSql.Puntos = modelPersona.Puntos;
                db.Entry(oPersonasSql).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.PersonaDeleteRequest idPersona)
        {
            using (Models.CrudExamenContext db = new Models.CrudExamenContext())
            {
                Models.PersonasSql oPersonasSql = db.PersonasSqls.Find(idPersona.Id);
                db.PersonasSqls.Remove(oPersonasSql);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
