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
    public class PetBusiness : IPetBusiness
    {
        private readonly IPetRepository _repo;

        public PetBusiness(IPetRepository repo)
        {
            _repo = repo;
        }

        public async Task<Pet[]> GetAllPets()
        {
            var result = await _repo.GetAllPets();
            if (result.Equals(null))
                throw new DataNotFoundException("Não foram encontrados Pets cadastrados.");
            else
                return result;
        }
    }
}
