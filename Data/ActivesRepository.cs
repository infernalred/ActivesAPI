using ActivesAPI.Helpers;
using ActivesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Data
{
    public class ActivesRepository : IActivesRepository
    {
        private readonly DataContext _context;

        public ActivesRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Computer> GetComputer(int id)
        {
            var computer = await _context.Computers.Include(x => x.User).ThenInclude(x => x.Room).Include(x => x.Network).FirstOrDefaultAsync(c => c.Id == id);

            return computer;
        }

        public async Task<PageList<Computer>> GetComputers(UserParams userParams)
        {
            var computers = _context.Computers.Include(x => x.User).Include(x => x.Network).AsQueryable();

            if (userParams.Search != null)
            {
                userParams.Search = userParams.Search.TrimStart().TrimEnd();
                computers = computers.Where(c => c.Inventory.Contains(userParams.Search) || c.Name.Contains(userParams.Search));
            }

            return await PageList<Computer>.CreateAsync(computers, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Monitor> GetMonitor(int id)
        {
            var monitor = await _context.Monitors.Include(x => x.User).ThenInclude(x => x.Room).Include(x => x.Vendor).FirstOrDefaultAsync(c => c.Id == id);

            return monitor;
        }

        public async Task<PageList<Monitor>> GetMonitors(UserParams userParams)
        {
            var monitors = _context.Monitors.Include(x => x.User).Include(x => x.Vendor).AsQueryable();

            if (userParams.Search != null)
            {
                userParams.Search = userParams.Search.TrimStart().TrimEnd();
                monitors = monitors.Where(c => c.Inventory.Contains(userParams.Search) || c.Serial.Contains(userParams.Search));
            }

            return await PageList<Monitor>.CreateAsync(monitors, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Room).ToListAsync(); //Include(x => x.Room)
            return users;
        }
        public async Task<IEnumerable<Vendor>> GetVendors()
        {
            var vendors = await _context.Vendors.ToListAsync();
            return vendors;
        }

        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;
    }
}
