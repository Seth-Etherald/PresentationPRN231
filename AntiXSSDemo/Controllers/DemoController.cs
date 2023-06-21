using AntiXSSDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace AntiXSSDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DemoController : ControllerBase
    {
        private List<InputModel> _data = new() {
            new() {Username = "First user", Email = "stunghy@gmail.com"},
            new() {Username = "Second user", Email = "demomail@xyz.com"},
            new() {Username = "Third user", Email = "mail@mail.com"}
        };

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_data);
        }

        [HttpPut]
        public IActionResult Add(InputModel model)
        {
            _data.Add(model);
            return Ok(_data);
        }
    }
}