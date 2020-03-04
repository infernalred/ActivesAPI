using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivesAPI.Data;
using ActivesAPI.Dtos;
using ActivesAPI.Helpers;
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
        private readonly IdToInventory _idToInventory;

        public ActivesController(IActivesRepository repo, IMapper mapper, IdToInventory idToInventory)
        {
            _repo = repo;
            _mapper = mapper;
            _idToInventory = idToInventory;
        }

        //GET: api/Actives/GetComputers
        [HttpGet(Name = "GetComputers")]
        [Route("[action]")]
        public async Task<IActionResult> GetComputers([FromQuery]UserParams userParams)
        {
            var computers = await _repo.GetComputers(userParams);
            var computersReturn = _mapper.Map<IEnumerable<ComputerForShowDto>>(computers);
            Response.AddPagination(computers.CurrentPage, computers.PageSize, computers.TotalCount, computers.TotalPage);
            return Ok(computersReturn);
        }

        //GET: api/Actives/GetComputer/id
        [HttpGet("{id}", Name = "GetComputer")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetComputer(int id)
        {
            var computer = await _repo.GetComputer(id);
            //var computersReturn = _mapper.Map<IEnumerable<ComputerForShowDto>>(computer);
            return Ok(computer);
        }

        //Save new computer
        [HttpPost(Name = "AddComputer")]
        [Route("[action]")]
        public async Task<IActionResult> AddComputer([FromBody]ComputerNewDto computerNewDto)
        {
            var computerToAdd = _mapper.Map<Computer>(computerNewDto);
            _repo.Add(computerToAdd);
            if (await _repo.SaveAll())
            {
                if (await _idToInventory.UpdateInventory(computerToAdd))
                    return NoContent();
            }
                

            throw new Exception($"Creating meeting failed on save");
        }

        //Update computer
        [HttpPut("{id}", Name = "UpdateComputer")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateComputer(int id, [FromBody]ComputerUpdateDto computerUpdateDto)
        {
            var computerFromRepo = await _repo.GetComputer(id);
            foreach (var item in computerFromRepo.Network)
            {
                _repo.Delete(item);
            }

            _mapper.Map(computerUpdateDto, computerFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating computer {computerUpdateDto.Name} failed on server");
        }

        [HttpGet(Name = "GetMonitors")]
        [Route("[action]")]
        public async Task<IActionResult> GetMonitors([FromQuery]UserParams userParams)
        {
            var monitors = await _repo.GetMonitors(userParams);
            Response.AddPagination(monitors.CurrentPage, monitors.PageSize, monitors.TotalCount, monitors.TotalPage);
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
