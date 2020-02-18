using ActivesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Data
{
    public interface IActivesRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Computer>> GetComputers();
        Task<IEnumerable<User>> GetUsers();
        Task<Computer> GetComputer(int id);
        Task<Monitor> GetMonitors();
        Task<Monitor> GetMonitor(int id);
    }
}
