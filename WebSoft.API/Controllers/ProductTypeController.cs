using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSoft.API.DbHelper;
using WebSoft.API.Models.Dto;

namespace WebSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly WebDbContext context;
        public ProductTypeController(WebDbContext _context)
        {
            context = _context;
        }

        //Get All Product Types
        //GET: http://localhost:port/ProductType
        [HttpGet]
        public IActionResult GetAll() { 

            //Get all data from domain
            var productTypes = context.ProductTypes.ToList();

            //maping data from products to dto
            var productTypesDto = new List<DtoProductType>();
            foreach (var productType in productTypes)
            {
                productTypesDto.Add(new DtoProductType()
                {
                    Id = productType.Id,
                    Name = productType.Name,
                });
            }

            //Return Dtos
            return Ok(productTypesDto);
        }
        //Get Single Product Types
        //GET: http://localhost:port/ProductType/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id) { 

            //Get single data from domain
            var productType = context.ProductTypes.FirstOrDefault( z => z.Id == id);
            //var productType = context.ProductTypes.Find(id); 
            if (productType == null)
            {
                return NotFound();
            }

            //maping data from domain to dto
            var productTypeDto = new DtoProductType
            {
                Id = productType.Id,
                Name = productType.Name,
            };

            return Ok(productTypeDto);
        }
    }
}
