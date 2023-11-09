using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceContext ecommerceContext;

        public ProductsController(EcommerceContext ecommerceContext)
        {
            this.ecommerceContext = ecommerceContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = ecommerceContext.Products.ToList();

            if (products != null)
            {
                Console.WriteLine("Hello from controller");
                return products;
            }

            return NotFound();
        }
    }
}
