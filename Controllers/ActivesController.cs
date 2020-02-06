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
        [HttpGet]
        public async Task<IActionResult> GetComputers()
        {
            var computers = await _repo.GetComputers();
            return Ok(computers);
        }



        // GET: api/Actives
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Actives/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Actives
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Actives/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
