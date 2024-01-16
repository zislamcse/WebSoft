using WebSoft.API.Models.Domain;

namespace WebSoft.API.Repositories.Interface
{
    public interface IProductType
    {
        Task<List<ProductTypeModels>> GetAllAsync();
    }
}
