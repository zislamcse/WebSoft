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

        public async Task<ProductTypeModels?> GetByIdAsync(Guid id)
        {
            var data = await _context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);

            if(data == null) {
                return null;
            }
            return data;
        }

        public async Task<ProductTypeModels> CreateAsync(ProductTypeModels productType)
        {
            await _context.ProductTypes.AddAsync(productType);
            await _context.SaveChangesAsync();
            return productType;
        }

        public async Task<ProductTypeModels?> UpdateAsync(Guid id, ProductTypeModels productType)
        {
            var data = await _context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);

            if (data == null)
            {
                return null;
            }

            data.Name = productType.Name;

            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<ProductTypeModels?> DeleteAsync(Guid id)
        {
            var data = await _context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);

            if (data == null)
            {
                return null;
            }

            _context.ProductTypes.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

    }
}
