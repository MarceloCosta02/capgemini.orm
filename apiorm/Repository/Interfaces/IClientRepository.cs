﻿using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client[]> GetAllClients();
    }
}
