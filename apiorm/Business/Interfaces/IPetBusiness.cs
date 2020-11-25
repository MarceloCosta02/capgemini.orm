using apiorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Business.Interfaces
{
    public interface IPetBusiness
    {
        Task<Pet[]> GetAllPets();
    }
}
