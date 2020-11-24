using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Models
{
    public class PetShop
    {
        public int PetShopId { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Pet> Pets { get; set; }
        public List<PetShopClient> PetShopClients { get; set; }

    }
}
