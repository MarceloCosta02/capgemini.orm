using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Business.Interfaces
{
    public interface IClientBusiness
    {
        Task<Client[]> GetAllClients();
        Task<Client> CreateClient(Client model);
    }
}
