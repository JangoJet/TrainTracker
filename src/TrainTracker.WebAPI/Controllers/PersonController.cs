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
            return Ok(_service.GetPeople());
        }
    }
}