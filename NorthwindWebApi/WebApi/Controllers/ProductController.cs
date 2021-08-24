using Business.Abstract;
using Business.Dto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(template: "[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetDetailedOjectList()
        {
            var result = _productService.DetailedOjectList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetDetailedList()
        {
            var result = _productService.DetailedList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost(template: "[action]")]
        public IActionResult Add([FromBody] ProductView productView)
        {
            var result = _productService.Add(productView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut(template: "[action]")]
        public IActionResult Update([FromBody] ProductView productView)
        {
            var result = _productService.Update(productView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete(template: "[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
