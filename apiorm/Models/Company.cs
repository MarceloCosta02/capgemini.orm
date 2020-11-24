using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyCane { get; set; }
        public string CNPJ { get; set; }
        public int PetshopId { get; set; }
        public PetShop PetShop { get; set; }
    }
}
