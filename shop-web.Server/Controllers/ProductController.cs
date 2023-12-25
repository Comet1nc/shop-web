using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_web.Server.Entities;
using shop_web.Server.Models;
using shop_web.Server.Services;

namespace shop_web.Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    /*[Authorize]*/
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        /*[AllowAnonymous]*/
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _productService.GetAll();

            if (products is null)
            {
                return NotFound("Not found");
            }

            return Ok(products);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.Create(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var isDeleted = _productService.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ProductDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _productService.Update(dto, id);

            if (isUpdated)
            {
                return Ok();
            }

            return NotFound();

        }
    }
}
