using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using System.Collections.Generic;

namespace ECommerceServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
                                    IGenericRepository<ProductBrand> brandRepo,
                                    IGenericRepository<ProductType> typeRepo)
        {
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAll()
        {
            var products = await productRepo.GetAllAsync();

            if (products != null)
            {
                return Ok(products);
            }

            return new List<Product>().AsReadOnly();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await productRepo.GetById(id);

            if (product != null)
            {
                return Ok(product);
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
