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
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _context;

        public PetRepository(PetShopContext context)
        {
            _context = context;
        }

        public async Task<Pet[]> GetAllPets()
        {
            IQueryable<Pet> query = _context.Pet;

            query = query.AsNoTracking().OrderBy(p => p.PetId);
            return await query.ToArrayAsync();
        }
    }
}
