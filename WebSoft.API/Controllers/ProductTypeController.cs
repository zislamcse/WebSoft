﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSoft.API.DbHelper;
using WebSoft.API.Mapping;
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
        private readonly IMapper mapper;

        public ProductTypeController(WebDbContext _context, IProductType productType, IMapper mapper)
        {
            context = _context;
            _productType = productType;
            this.mapper = mapper;
        }

        //Get All Product Types
        //GET: http://localhost:port/ProductType
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get all data from domain
            var productTypes = await _productType.GetAllAsync();

            //maping data from products to dto
            ////var productTypesDto = new List<DtoProductType>();
            ////foreach (var productType in productTypes)
            ////{
            ////    productTypesDto.Add(new DtoProductType()
            ////    {
            ////        Id = productType.Id,
            ////        Name = productType.Name,
            ////    });
            ////}

            var productTypesDto = mapper.Map<List<DtoProductType>>(productTypes);

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
            var productType = await _productType.GetByIdAsync(id);
            //var productType = context.ProductTypes.Find(id); 
            if (productType == null)
            {
                return NotFound();
            }

            //maping data from domain to dto
            var productTypeDto = mapper.Map<DtoProductType>(productType);

            return Ok(productTypeDto);
        }

        //POST to create new product type
        //POST http://localhost:7104/producttype/create

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DtoProductTypeAdd productTypeAdd)
        {
            // Map Dto to Domain model
            var productTypeDomain = mapper.Map<ProductTypeModels>(productTypeAdd);

            //Use Domain maodel to create
            await _productType.CreateAsync(productTypeDomain);

            //Map domain model back to dto
            var productType = mapper.Map<DtoProductType>(productTypeDomain);

            return CreatedAtAction(nameof(GetById), new { id = productTypeDomain.Id }, productType);
        }

        //PUT to update product type
        //PUT: http://localhost:7104/producttype/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DtoProductTypeAdd dtoProductTypeUpdate)
        {
            // Map Dto to Doman
            var producttypedomain = mapper.Map<ProductTypeModels>(dtoProductTypeUpdate);

            //Check if Exist
            producttypedomain = await _productType.UpdateAsync(id, producttypedomain);
            if (producttypedomain == null)
            {
                return NotFound();
            }

            //Map domain model to dto
            var producttypedto = mapper.Map<DtoProductType>(producttypedomain);

            return Ok(producttypedto);
        }

        //Delete to delete product type
        //PUT: http://localhost:7104/producttype/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //Return data from server by domain model
            var productTypedomain = await _productType.DeleteAsync(id);

            if (productTypedomain == null)
            {
                return NotFound();
            }

            //return delete region back
            //map domain model to dto
            var regiondto = mapper.Map<DtoProductType>(productTypedomain);

            return Ok(regiondto);
        }
    }
}
