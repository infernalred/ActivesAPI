using ActivesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Data
{
    public class ActivesRepository : IActivesRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Computer> GetComputer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Computer> GetComputers()
        {
            throw new NotImplementedException();
        }

        public Task<Monitor> GetMonitor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Monitor> GetMonitors()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
