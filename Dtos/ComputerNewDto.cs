using ActivesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Dtos
{
    public class ComputerNewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool OutOffOffice { get; set; }
        public bool Broken { get; set; }
        public int UserId { get; set; }
        public ICollection<NetworkNewDto> Network { get; set; }
    }
}
