using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivesAPI.Data;
using ActivesAPI.Dtos;
using ActivesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivesController : ControllerBase
    {
        private readonly IActivesRepository _repo;
        private readonly IMapper _mapper;

        public ActivesController(IActivesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET: api/Actives/GetComputers
        [HttpGet(Name = "GetComputers")]
        [Route("[action]")]
        public async Task<IActionResult> GetComputers()
        {
            var computers = await _repo.GetComputers();
            var computersReturn = _mapper.Map<IEnumerable<ComputerForShowDto>>(computers);
            return Ok(computersReturn);
        }

        //Save new computer
        [HttpPost(Name = "AddComputer")]
        [Route("[action]")]
        public async Task<IActionResult> AddComputer([FromBody]ComputerNewDto computerNewDto)
        {
            var computerToAdd = _mapper.Map<Computer>(computerNewDto);
            computerToAdd.Inventory = computerToAdd.Id.ToString();
            _repo.Add(computerToAdd);
            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Creating meeting failed on save");
        }

        [HttpGet(Name = "GetMonitors")]
        [Route("[action]")]
        public async Task<IActionResult> GetMonitors()
        {
            var monitors = await _repo.GetMonitors();
            return Ok(monitors);
        }

        [HttpGet(Name = "GetUsers")]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            return Ok(users);
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
