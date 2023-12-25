using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web.Server.Entities;
using shop_web.Server.Models;
using shop_web.Server.Services;

namespace shop_web.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("auth/register")]
        public ActionResult RegisterUser([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registered = _accountService.RegisterUser(dto);
            
            if (registered)
            {
                return Ok();
            }

            return BadRequest("Email already taken");
        }

        [HttpPost("auth/login")]
        public ActionResult<int> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int userId = _accountService.LoginUser(dto);

            if (userId == -1)
            {
                return BadRequest("Invalid data.");
            }

            return Ok(userId);
        }

        [HttpGet("users/{userId}/products")]
        public ActionResult<IEnumerable<Product>> GetProductsForUser(int userId)
        {
            var products = _accountService.GetProductsForUser(userId);

            if (products != null)
            {
                return Ok(products);
            }

            return NotFound("No products.");
            
        }

        [HttpPost("users/{userId}/products/{productId}")]
        public IActionResult AddProductToUser(int userId, int productId)
        {
            bool success = _accountService.AddProductToUser(userId, productId);

            if(success)
            {
                return Ok("{}");
            }

            return BadRequest("Cant add product");
        }

        [HttpDelete("users/{userId}/products/{productId}")]
        public IActionResult RemoveProductFromUser(int userId, int productId)
        {
            bool success = _accountService.RemoveProductFromUser(userId, productId);
            if(success) {
                return Ok("{}");
            }
            return BadRequest("Error");

        }

        [HttpDelete("users/{userId}/products")]
        public IActionResult RemoveAllProductsFromUser(int userId)
        {
            bool success = _accountService.RemoveAllProductsFromUser(userId);
            if (success)
            {
                return Ok("{}");
            }
            return BadRequest("Error");

        }

    }
}
