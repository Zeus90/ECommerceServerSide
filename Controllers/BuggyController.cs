using ECommerceServerSide.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServerSide.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly EcommerceContext context;

        public BuggyController(EcommerceContext context)
        {
            this.context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = context.Products.Find(42);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = context.Products.Find(42);
            //var test = product.ToString();  

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
