using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntiCSRFDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public DemoController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }
    }
}