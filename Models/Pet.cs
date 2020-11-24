﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
