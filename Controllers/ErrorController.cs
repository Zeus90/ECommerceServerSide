using ECommerceServerSide.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServerSide.Controllers
{
    [Route("errors/{statuscode}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        public IActionResult Error(int statuscode)
        {
            return new ObjectResult(new ApiResponse(statuscode));
        }
    }
}
