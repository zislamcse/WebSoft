using Microsoft.EntityFrameworkCore;
using WebSoft.API.DbHelper;
using WebSoft.API.Models.Domain;
using WebSoft.API.Repositories.Interface;

namespace WebSoft.API.Repositories.Services
{
    public class SProductType : IProductType
    {
        private readonly WebDbContext _context;
        public SProductType(WebDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductTypeModels>> GetAllAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
