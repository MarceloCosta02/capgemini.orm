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
    public class PetShopBusiness : IPetShopBusiness
    {
        private readonly IPetShopRepository _petShop;
        private readonly IRepositoryEF _repo;

        public PetShopBusiness(IPetShopRepository petShop, IRepositoryEF repo)
        {
            _petShop = petShop;
            _repo = repo;
        }

        public async Task<PetShop[]> GetAllPetShops()
        {
            var result = await _petShop.GetAllPetShops();
            if (result.Equals(null))
                throw new DataNotFoundException("Não foram encontrados PetShops cadastrados.");
            else
                return result;
        }

        public async Task<PetShop> GetPetShopById(int id)
        {
            var result = await _petShop.GetPetShopById(id);
            if (result.Equals(null))
                throw new DataNotFoundException($"Não foi encontrado um PetShop com o ID: {id}.");
            else
                return result;
        }

        public async Task<PetShop[]> GetPetShopByName(string name)
        {
            if(name.Equals(null) || name.Equals(""))
                throw new ModelFieldIsNullException($"O Parâmetro name está vazio ou nulo.");
            else
            {
                var result = await _petShop.GetPetShopByName(name);
                if (result.Equals(null))
                    throw new DataNotFoundException($"Não foi encontrado um PetShop com o Nome: {name}.");
                else
                    return result;
            }           
        }

        public async Task<PetShop> CreatePetShop(PetShop model)
        {
            PetShoptIsNotNull(model);

            _repo.Add(model);

            if (await _repo.SaveChangeAsync())
                return model;
            else            
                throw new InvalidOperationException();         
            
        }

        public async Task<PetShop> UpdatePetShop(PetShop model, int id)
        {
            PetShoptIsNotNull(model);

            var petShop = await _petShop.GetPetShopById(id);

            if (petShop == null)            
                throw new DataNotFoundException($"Não foi encontrado um PetShop com o ID: {id}.");            
            else
            {
                _repo.Update(model);

                if (await _repo.SaveChangeAsync())                
                    return model;                
                else
                    throw new InvalidOperationException();
            }
        }

        public async void DeletePetShop(int id)
        {
            var petShop = await _petShop.GetPetShopById(id);

            if (petShop == null)
                throw new DataNotFoundException($"Não foi encontrado um PetShop com o ID: {id}.");
            else
            {
                _repo.Delete(petShop);

                if (!await _repo.SaveChangeAsync())
                    throw new InvalidOperationException();
            }
        }

        /// <summary> 
        /// Verifica se os campos do PetShop não são nulos
        /// </summary>
        public void PetShoptIsNotNull(PetShop petShop)
        {
            if (petShop.PetShopId.Equals(0))
                throw new ModelFieldIsNullException("O ID do PetShop não pode ser 0");
            else if (string.IsNullOrEmpty(petShop.Name))
                throw new ModelFieldIsNullException("O nome do Cliente está vazio");
            else if (string.IsNullOrEmpty(petShop.Company.CompanyCane))
                throw new ModelFieldIsNullException("O nome da Compania está vazio");
            else if (string.IsNullOrEmpty(petShop.Company.CNPJ))
                throw new ModelFieldIsNullException("O CNPJ da Compania está vazio");
            else if (!petShop.Pets.Any())
                throw new ModelFieldIsNullException("Deve ser informado ao menos um Pet");
        }
      
    }
}
