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
    }
}
