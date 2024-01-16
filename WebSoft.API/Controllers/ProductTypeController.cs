using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSoft.API.DbHelper;
using WebSoft.API.Models.Domain;
using WebSoft.API.Models.Dto;
using WebSoft.API.Repositories.Interface;

namespace WebSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly WebDbContext context;
        private readonly IProductType _productType;
        public ProductTypeController(WebDbContext _context, IProductType productType)
        {
            context = _context;
            _productType = productType;
        }

        //Get All Product Types
        //GET: http://localhost:port/ProductType
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get all data from domain
            var productTypes = await _productType.GetAllAsync();

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
        public async Task<IActionResult> GetById(Guid id)
        {

            //Get single data from domain
            var productType = await context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);
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

        //POST to create new product type
        //POST http://localhost:7104/producttype/create

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DtoProductTypeAdd productTypeAdd)
        {
            // Map Dto to Domain model
            var productTypeDomain = new ProductTypeModels
            {
                Name = productTypeAdd.Name,
            };

            //Use Domain maodel to create
            await context.ProductTypes.AddAsync(productTypeDomain);
            await context.SaveChangesAsync();

            //Map domain model back to dto
            var productType = new ProductTypeModels
            {
                Id = productTypeDomain.Id,
                Name = productTypeDomain.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = productTypeDomain.Id }, productType);
        }

        //PUT to update product type
        //PUT: http://localhost:7104/producttype/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DtoProductTypeAdd dtoProductTypeUpdate)
        {
            //Check if Exist
            var producttypedomain = await context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);
            if (producttypedomain == null)
            {
                return NotFound();
            }

            //Map dto to domain
            producttypedomain.Name = dtoProductTypeUpdate.Name;

            //Update query
            await context.SaveChangesAsync();

            //Map domain model to dto
            var producttypedto = new DtoProductType
            {
                Id = producttypedomain.Id,
                Name = dtoProductTypeUpdate.Name,
            };

            return Ok(producttypedto);
        }

        //Delete to delete product type
        //PUT: http://localhost:7104/producttype/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //Return data from server by domain model
            var productTypedomain = await context.ProductTypes.FirstOrDefaultAsync(z => z.Id == id);

            if (productTypedomain == null)
            {
                return NotFound();
            }

            //delete product type
            context.ProductTypes.Remove(productTypedomain);
            await context.SaveChangesAsync();

            //return delete region back
            //map domain model to dto
            var regiondto = new DtoProductType
            {
                Id = productTypedomain.Id,
                Name = productTypedomain.Name,
            };

            return Ok(regiondto);
        }
    }
}
