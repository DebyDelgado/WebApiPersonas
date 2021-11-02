using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPersonas.Data;
using WebApiPersonas.Models;


namespace WebApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly PeopleDbContext context;

        public PeopleController (PeopleDbContext context)
        {
            this.context = context;

        }

        //public object People { get; private set; }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return context.People.ToList();

        }
        [HttpGet("{id}")]

        public ActionResult<Person> Get (int id)
        {
            return context.People.Find(id);


        }

        public ActionResult Post (Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult Put (int id, Person person)
        {
            if (id!=person.Id)
            {
                return BadRequest();


            }
            context.Entry(person).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            Person person = context.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            context.People.Remove(person);
            context.SaveChanges();

            return person;
        }

    }
}
