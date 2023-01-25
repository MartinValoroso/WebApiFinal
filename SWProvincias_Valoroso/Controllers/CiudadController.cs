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
    public class CiudadController : ControllerBase
    {
        
        
            // *********************** ESTO VA SIEMPRE AL PPIO!! **************************

            //propiedades
            private readonly DbPaisFinalContext context;

        //constructor
        public CiudadController(DbPaisFinalContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();

        }

        // INSTERTAR 


        [HttpPost]
        public ActionResult<Ciudad> Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok(); // devuelve el status code 200 ok 

        }

        // MODIFICAR


        [HttpPut("{id}")]
        public ActionResult<Ciudad> Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

        // BORRAR _ DELETE


        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from c in context.Ciudades
                          where c.IdCiudad == id
                          select c).SingleOrDefault();
            if (ciudad == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;

        }


    }
}

