using Business.Abstract;
using Business.Dto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(template: "[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetList()
        {
            var result = _employeeService.GetList();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost(template: "[action]")]
        public IActionResult Add([FromBody] EmployeeView employeeView)
        {
            var result = _employeeService.Add(employeeView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut(template: "[action]")]
        public IActionResult Update([FromBody] EmployeeView employeeView)
        {
            var result = _employeeService.Update(employeeView);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete(template: "[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}

