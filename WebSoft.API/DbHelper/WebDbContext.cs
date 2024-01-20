using Microsoft.EntityFrameworkCore;
using WebSoft.API.Models.Domain;

namespace WebSoft.API.DbHelper
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductTypeModels> ProductTypes { get; set; }
        public DbSet<CompanyModels> Companies { get; set; }
        public DbSet<ProductModels> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for producttypes
            var productTypes = new List<ProductTypeModels>()
            {
                new ProductTypeModels()
                {
                    Id = Guid.Parse("3b583571-3d65-4df0-ac8b-cdb439ade2b7"),
                    Name = "Tablet"
                },
                new ProductTypeModels()
                {
                    Id = Guid.Parse("e6c4969b-69de-43a9-90b4-9c9bc763a3f5"),
                    Name = "Capsule"
                }
            };

            //Seed producttypes to the database
            modelBuilder.Entity<ProductTypeModels>().HasData(productTypes);
        }
    }
}
