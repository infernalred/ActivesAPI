using ActivesAPI.Helpers;
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
        //Task<IEnumerable<Computer>> GetComputers();
        Task<PageList<Computer>> GetComputers(UserParams userParams);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Vendor>> GetVendors();
        Task<Computer> GetComputer(int id);
        Task<PageList<Monitor>> GetMonitors(UserParams userParams);
        Task<Monitor> GetMonitor(int id);
    }
}
