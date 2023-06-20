using AntiCSRFDemo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntiCSRFDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DemoController : Controller
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public DemoController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentDTO student)
        {
            try
            {
                _context.Students.Add(_mapper.Map<StudentDTO, Student>(student));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}