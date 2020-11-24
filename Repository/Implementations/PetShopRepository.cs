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

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<PetShop[]> GetAllPetShops()
        {
            IQueryable<PetShop> query = _context.PetShop
                .Include(h => h.Pets)
                .Include(h => h.Company);          

            query = query.AsNoTracking().OrderBy(p => p.PetShopId);
            return await query.ToArrayAsync();
        }

        public async Task<PetShop> GetPetShopById(int id)
        {
            // Adiciona identidade e armas no get
            IQueryable<PetShop> query = _context.PetShop
                .Include(h => h.Pets)
                .Include(h => h.Company);

            query = query.AsNoTracking().OrderBy(p => p.PetShopId);

            return await query.FirstOrDefaultAsync(p => p.PetShopId == id);
        }

        public async Task<PetShop[]> GetPetShopByName(string name)
        {
            IQueryable<PetShop> query = _context.PetShop
                .Include(h => h.Pets)
                .Include(h => h.Company);

            query = query.AsNoTracking()
                .Where(p => p.Name.Contains(name))
                .OrderBy(p => p.PetShopId);

            return await query.ToArrayAsync();
        }

        public async Task<Pet[]> GetAllPets()
        {
            IQueryable<Pet> query = _context.Pet;

            query = query.AsNoTracking().OrderBy(p => p.PetId);
            return await query.ToArrayAsync();
        }

        public async Task<Client[]> GetAllClients()
        {
            IQueryable<Client> query = _context.Client;

            query = query.AsNoTracking().OrderBy(p => p.ClientId);
            return await query.ToArrayAsync();
        }

        public async Task<Company[]> GetAllCompanys()
        {
            IQueryable<Company> query = _context.Company;

            query = query.AsNoTracking().OrderBy(p => p.CompanyId);
            return await query.ToArrayAsync();
        }
    }
}
