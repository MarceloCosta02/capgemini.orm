using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Models
{
    public class ClientPetShop
    {
        // Aplica nessa classe o relacionamento n pra n para as 2

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int PetshopId { get; set; }
        public PetShop PetShop { get; set; }
    }
}
