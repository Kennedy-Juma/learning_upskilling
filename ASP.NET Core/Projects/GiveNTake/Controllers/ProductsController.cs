using GiveNTake.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiveNTake.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GiveNTakeContext context;
        public ProductsController(GiveNTakeContext _context) 
        {
            context=_context;
        }
        public string[] GetProduct()
        {
            return new[]
            {
                "1 - Microwave",
                "2 - Washing Machine",
                "3 - Mirror"
            };
        }

        [HttpPost("")]
        public ActionResult<NewRequestDTO> AddNewProduct([FromBody]NewRequestDTO newProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newProduct);
        }
    }
}
