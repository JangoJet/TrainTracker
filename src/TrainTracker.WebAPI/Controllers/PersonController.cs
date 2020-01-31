using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Entities;
using TrainTracker.Core.Services;

namespace TrainTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service) {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Person> GetById(int Id)
        {
            var person = _service.FindById(Id);
            if (person == null) return NotFound();
            return person;
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            //Only needed for the test.  APIController actually handles this.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Create(person);
            return CreatedAtAction(nameof(GetById), new { person.Id }, person);
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {

            try
                {
                var person = _service.FindById(Id);
                if (person == null) return NotFound();
                _service.Remove(Id, person);
                }
            catch (IndexOutOfRangeException)
            {
                return NotFound();
            }
            catch (Exception)
             {
              return new StatusCodeResult(StatusCodes.Status500InternalServerError);
             }
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(Person person)
        {
            if (_service.FindById(person.Id) == null) return NotFound();
            try
            {
                _service.Update(person);
            }
            catch(Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }

}