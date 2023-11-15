using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Specifications;
using ECommerceServerSide.Dtos;
using AutoMapper;

namespace ECommerceServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
                                    IGenericRepository<ProductBrand> brandRepo,
                                    IGenericRepository<ProductType> typeRepo,
                                    IMapper mapper)
        {
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
        {
            var specs = new ProductSpecification();
            var products = await productRepo.GetAllAsync(specs);

            if (products != null)
            {
                return products.Select(product => mapper.Map<Product, ProductDto>(product)).ToList();
            }

            return new List<ProductDto>().AsReadOnly();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var specs = new ProductSpecification(id);
            var product = await productRepo.GetEntityWithSpecsAsync(specs);

            if (product != null)
            {
                return mapper.Map<Product, ProductDto>(product);
            }

            return NotFound();
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await brandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await typeRepo.GetAllAsync());
        }
    }
}
