using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSoft.API.Controllers
{
    //https://localhost:7104/Products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] products = new string[] { "Napa 500", "Napa 300", "Rupa", "Cef-3" };
            return Ok(products);
        }
    }
}
