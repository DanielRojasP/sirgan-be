using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sirgan_be.Models;

namespace sirgan_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        ////show users
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            //return Ok(_context);
            return Ok(await _context.users.ToListAsync());
        }
    }
}
