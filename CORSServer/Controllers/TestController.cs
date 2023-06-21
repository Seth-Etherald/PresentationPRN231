using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CORSServer.Model;
using Microsoft.AspNetCore.Cors;

namespace CORSServer.Controllers
{
    //[EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
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
    }
}