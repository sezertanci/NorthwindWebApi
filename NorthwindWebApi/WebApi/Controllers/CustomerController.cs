using Business.Abstract;
using Business.Dto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class CustomerController : Controller
        {
            private readonly ICustomerService _customerService;

            public CustomerController(ICustomerService customerService)
            {
                _customerService = customerService;
            }

            [HttpGet(template: "[action]/{id}")]
            public IActionResult Get(string id)
            {
                var result = _customerService.GetById(id);

                if(result.Success) return Ok(result);

                return BadRequest(result);
            }

            [HttpGet(template: "[action]")]
            public IActionResult GetList()
            {
                var result = _customerService.GetList();

                if(result.Success) return Ok(result);

                return BadRequest(result);
            }

            [HttpPost(template: "[action]")]
            public IActionResult Add([FromBody] CustomerView customerView)
            {
                var result = _customerService.Add(customerView);

                if(result.Success) return Ok(result);

                return BadRequest(result);
            }

            [HttpPut(template: "[action]")]
            public IActionResult Update([FromBody] CustomerView customerView)
            {
                var result = _customerService.Update(customerView);

                if(result.Success) return Ok(result);

                return BadRequest(result);
            }

            [HttpDelete(template: "[action]/{id}")]
            public IActionResult Delete(string id)
            {
                var result = _customerService.Delete(id);

                if(result.Success) return Ok(result);

                return BadRequest(result);
            }
        }
    }

