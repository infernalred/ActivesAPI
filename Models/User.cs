﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
