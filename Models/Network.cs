using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Models
{
    public class Network
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string MAC { get; set; }
    }
}
