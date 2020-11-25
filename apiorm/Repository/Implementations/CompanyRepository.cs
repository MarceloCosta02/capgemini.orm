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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PetShopContext _context;

        public CompanyRepository(PetShopContext context)
        {
            _context = context;
        }

        public async Task<Company[]> GetAllCompanys()
        {
            IQueryable<Company> query = _context.Company;

            query = query.AsNoTracking().OrderBy(p => p.CompanyId);
            return await query.ToArrayAsync();
        }
    }
}
