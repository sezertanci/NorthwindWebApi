using Business.Abstract;
using Business.Dto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(template: "[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _categoryService.GetById(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost(template: "[action]")]
        public IActionResult Add([FromBody] CategoryView categoryView)
        {
            var result = _categoryService.Add(categoryView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut(template: "[action]")]
        public IActionResult Update([FromBody] CategoryView categoryView)
        {
            var result = _categoryService.Update(categoryView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete(template: "[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}

