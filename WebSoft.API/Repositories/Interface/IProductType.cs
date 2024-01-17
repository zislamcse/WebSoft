using WebSoft.API.Models.Domain;

namespace WebSoft.API.Repositories.Interface
{
    public interface IProductType
    {
        Task<List<ProductTypeModels>> GetAllAsync();

        Task<ProductTypeModels?> GetByIdAsync(Guid id);

        Task<ProductTypeModels> CreateAsync(ProductTypeModels productType);

        Task<ProductTypeModels?> UpdateAsync(Guid id, ProductTypeModels productType);

        Task<ProductTypeModels?> DeleteAsync(Guid id);
    }
}
