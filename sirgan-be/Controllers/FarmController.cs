using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sirgan_be.Models;

namespace sirgan_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly DataContext _context;

        public FarmController(DataContext context)
        {
            _context = context;
        }
        ////show user
        [HttpGet]
        public async Task<ActionResult<List<Farm>>> Get()
        {
            //return Ok(_context);
            return Ok(await _context.farms.ToListAsync());
        }
    }
}
