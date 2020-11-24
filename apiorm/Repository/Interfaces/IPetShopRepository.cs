using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Repository.Interfaces
{
    public interface IPetShopRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        Task<PetShop[]> GetAllPetShops();
        Task<PetShop> GetPetShopById(int id);
        Task<PetShop[]> GetPetShopByName(string name);

        Task<Client[]> GetAllClients();
        Task<Pet[]> GetAllPets();
        Task<Company[]> GetAllCompanys();
    }
}
