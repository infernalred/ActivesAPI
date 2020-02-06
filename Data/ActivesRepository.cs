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
            var computer = await _context.Computers.Include(x => x.User).Include(x => x.Network).FirstOrDefaultAsync(c => c.Id == id);

            return computer;
        }

        public async Task<IEnumerable<Computer>> GetComputers()
        {
            var computers = await _context.Computers.Include(x => x.User).Include(x => x.Network).ToListAsync();

            return computers;
        }

        public Task<Monitor> GetMonitor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Monitor> GetMonitors()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;
    }
}
