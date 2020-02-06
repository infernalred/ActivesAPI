using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivesAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivesController : ControllerBase
    {
        private readonly IActivesRepository _repo;

        public ActivesController(IActivesRepository repo)
        {
            _repo = repo;
        }

        //GET: api/Actives/GetComputers
        [HttpGet(Name = "GetComputers")]
        [Route("[action]")]
        public async Task<IActionResult> GetComputers()
        {
            var computers = await _repo.GetComputers();
            return Ok(computers);
        }

        [HttpGet(Name = "GetMonitors")]
        [Route("[action]")]
        public async Task<IActionResult> GetMonitors()
        {
            var monitors = await _repo.GetMonitors();
            return Ok(monitors);
        }


        // GET: api/Actives
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Actives/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Actives
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

    }
}
