using apiorm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Repository.Context
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

        public DbSet<PetShop> PetShop { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<PetShopClient> PetShopClient { get; set; }
        public DbSet<Company> Company { get; set; }

        // Explica para o Entity que as 2 chaves são chaves compostas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetShopClient>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.PetshopId });
            });
        }
    }
}
