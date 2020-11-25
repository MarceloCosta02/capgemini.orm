using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Business.Interfaces
{
    public interface IPetShopBusiness
    {
        Task<PetShop[]> GetAllPetShops();
        Task<PetShop> GetPetShopById(int id);
        Task<PetShop[]> GetPetShopByName(string name);
        Task<PetShop> CreatePetShop(PetShop model);
        Task<PetShop> UpdatePetShop(PetShop model, int id);
        void DeletePetShop(int id);
    }
}
