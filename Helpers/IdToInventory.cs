using ActivesAPI.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ActivesAPI.Models;

namespace ActivesAPI.Helpers
{
    public class IdToInventory
    {
        private readonly IActivesRepository _repo;

        public IdToInventory(IActivesRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> UpdateInventory(Computer computer)
        {
            var computerFromRepo = await _repo.GetComputer(computer.Id);
            computerFromRepo.Inventory = new string("1-" + computerFromRepo.Id);
            return await _repo.SaveAll();
        }

        public async Task<bool> UpdateInventory(Monitor monitor)
        {
            var monitorFromRepo = await _repo.GetMonitor(monitor.Id);
            monitorFromRepo.Inventory = new string("2-" + monitorFromRepo.Id);
            return await _repo.SaveAll();
        }
    }
}
