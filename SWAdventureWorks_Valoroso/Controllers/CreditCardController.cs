using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Valoroso.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Valoroso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        // *********************** ESTO VA SIEMPRE AL PPIO!! **************************

        //propiedades
        private readonly AdventureWorks2019Context context;

        //constructor
        public CreditCardController(AdventureWorks2019Context context)
        {
            this.context = context;

        }

        /* HACER:
            Get
            GetById
            GetbyName
            Post

        */

        // GET 

        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> Get()
        {
            return context.CreditCards.ToList();

        }

        //GET : api/creditcard/5
        //GET POR ID 
        [HttpGet("id/{id}")]
        public ActionResult<CreditCard> GetByID(int id)
        {
            CreditCard creditcard = (from c in context.CreditCards
                           where c.CreditCardId == id
                           select c).SingleOrDefault();
            return creditcard;

        }

        //GET : api/creditcard/cardtype
        //GET POR NOMBRE ---> USO CARDTYPE porque no tiene nombre
        [HttpGet("tipo/{cardtype}")]
        public ActionResult<IEnumerable<CreditCard>> GetByType(string type)
        {
            List<CreditCard> creditcard = (from c in context.CreditCards
                                     where c.CardType == type
                                     select c).ToList();
            return creditcard;

        }

        // INSTERTAR 

        //POST : api/creditcard

        [HttpPost]
        public ActionResult<CreditCard> Post(CreditCard creditcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.CreditCards.Add(creditcard);
            context.SaveChanges();
            return Ok(); // devuelve el status code 200 ok 

        }

        // MODIFICAR

        

        [HttpPut("{id}")]
        public ActionResult<CreditCard> Put(int id, [FromBody] CreditCard creditcard)
        {
            if (id != creditcard.CreditCardId)
            {
                return BadRequest();
            }

            context.Entry(creditcard).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

        //DELETE

        [HttpDelete("{id}")]
        public ActionResult<CreditCard> Delete(int id)
        {
            var creditCard = (from c in context.CreditCards
                         where c.CreditCardId == id
                         select c).SingleOrDefault();
            if (creditCard == null)
            {
                return NotFound();
            }
            context.CreditCards.Remove(creditCard);
            context.SaveChanges();
            return creditCard;

        }


    }
}
