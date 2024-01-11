namespace WebSoft.API.Models.Domain
{
    public class ProductModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double TP { get; set; }
        public double SalePrice { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid CompanyId { get; set; }
        public ProductTypeModels ProductType { get; set; }
        public CompanyModels Company { get; set; }
    }
}
