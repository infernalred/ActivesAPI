using ActivesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Dtos
{
    public class ComputerForShowDto
    {
        public int Id { get; set; }
        public string Inventory { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string LastUpdate { get; set; }
        public bool OutOffOffice { get; set; }
        public bool Broken { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Network> Network { get; set; }
    }
}
