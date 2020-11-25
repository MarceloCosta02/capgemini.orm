using apiorm.Business.Interfaces;
using apiorm.Exceptions;
using apiorm.Models;
using apiorm.Repository.Context;
using apiorm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Business.Implementations
{
    public class CompanyBusiness : ICompanyBusiness
    {
        private readonly ICompanyRepository _repo;

        public CompanyBusiness(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public async Task<Company[]> GetAllCompanys()
        {
            var result = await _repo.GetAllCompanys();
            if (result.Equals(null))
                throw new DataNotFoundException("Não foram encontrados Companias cadastrados.");
            else
                return result;
        }      
    }
}
