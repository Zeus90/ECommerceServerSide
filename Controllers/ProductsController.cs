using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using ECommerceServerSide.Dtos;
using AutoMapper;
using ECommerceServerSide.Errors;
using ECommerceServerSide.Helpers.Pagination;

namespace ECommerceServerSide.Controllers
{
    public class ProductsController : BaseController
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
        public async Task<ActionResult<Pagination<ProductDto>>> GetAll([FromQuery]ProductSpecsParams specsParams)
        {
            var specs = new ProductSpecification(specsParams);
            
            var countSpec = new ProductSpecsWithFilter(specsParams);

            var totalItems = await productRepo.CountAsync(countSpec);

            var products = await productRepo.GetAllAsync(specs);

            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(specsParams.PageIndex, specsParams.PageSize, totalItems, data));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse) ,StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductDto) ,StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var specs = new ProductSpecification(id);
            var product = await productRepo.GetEntityWithSpecsAsync(specs);

            if (product != null)
            {
                return mapper.Map<Product, ProductDto>(product);
            }

            return NotFound(new ApiResponse(404));
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
