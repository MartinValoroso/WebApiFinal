using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Valoroso.Data;
using SWProvincias_Valoroso.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Valoroso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        // *********************** ESTO VA SIEMPRE AL PPIO!! **************************

        //propiedades
        private readonly DbPaisFinalContext context;

        //constructor
        public ProvinciaController(DbPaisFinalContext context)
        {
            this.context = context;

        }

        //Get api/provincia
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();

        }

        // INSTERTAR 

        //POST : api/provincia

        [HttpPost]
        public ActionResult<Provincia> Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok(); // devuelve el status code 200 ok 

        }

        // MODIFICAR

        //PUT: api/provincia/2

        [HttpPut("{id}")]
        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

        // BORRAR _ DELETE

        // DELETE: Api/provincia/2

        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from p in context.Provincias
                         where p.IdProvincia == id
                         select p).SingleOrDefault();
            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;

        }


    }
}
