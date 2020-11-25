using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Repository.Interfaces
{
    public interface IPetShopRepository
    {
        Task<PetShop[]> GetAllPetShops();
        Task<PetShop> GetPetShopById(int id);
        Task<PetShop[]> GetPetShopByName(string name);
    }
}
