using apiorm.Models;
using apiorm.Repository.Context;
using apiorm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Repository.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly PetShopContext _context;

        public ClientRepository(PetShopContext context)
        {
            _context = context;
        }

        public async Task<Client[]> GetAllClients()
        {
            IQueryable<Client> query = _context.Client;

            query = query.AsNoTracking().OrderBy(p => p.ClientId);
            return await query.ToArrayAsync();
        }
    }
}
