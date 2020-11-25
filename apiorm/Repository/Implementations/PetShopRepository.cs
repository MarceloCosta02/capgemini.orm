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
    public class PetShopRepository : IPetShopRepository
    {
        private readonly PetShopContext _context;

        public PetShopRepository(PetShopContext context)
        {
            _context = context;
        }

        public async Task<PetShop[]> GetAllPetShops()
        {
            var query = GetQueryPetShop();

            query = query.AsNoTracking().OrderBy(p => p.PetShopId);
            return await query.ToArrayAsync();
        }

        public async Task<PetShop> GetPetShopById(int id)
        {
            var query = GetQueryPetShop();

            query = query
                .AsNoTracking()
                .OrderBy(p => p.PetShopId);

            return await query.FirstOrDefaultAsync(p => p.PetShopId == id);
        }

        public async Task<PetShop[]> GetPetShopByName(string name)
        {
            var query = GetQueryPetShop();

            query = query.AsNoTracking()
                .Where(p => p.Name.Contains(name))
                .OrderBy(p => p.PetShopId);

            return await query.ToArrayAsync();
        }

        private IQueryable<PetShop> GetQueryPetShop()
        {
            IQueryable<PetShop> query = _context.PetShop
               .Include(h => h.Pets)
               .Include(h => h.Company);

            return query;
        }
    }
}
