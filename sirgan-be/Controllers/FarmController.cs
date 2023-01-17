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

        //Connection with the database
        public FarmController(DataContext context)
        {
            _context = context;
        }
        //Show all farms
        [HttpGet]
        public async Task<ActionResult<List<Farm>>> Get()
        {
            //return Ok(_context);
            return Ok(await _context.farms.ToListAsync());
        }

        //Show an spefic farm based in the id
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> Get(int id)
        {
            return Ok(_context.farms
                .FromSqlRaw<Farm>("GetFarmByID {0}", id)
                .ToList()
                .FirstOrDefault());
        }

        //Save a new farm
        [HttpPost]
         public async Task<ActionResult<Farm>> Add(Farm newFarm)
        {
            _context.Database.ExecuteSqlRaw("SaveFarm  {0}, {1}, {2}",
            
                        newFarm.Id,
                        newFarm.Name,
                        newFarm.User_Id);

            return newFarm;          

        }
        //Update an existed farm
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Farm>>> UpdateFarm(Farm farm,int id)
        {

            var dbFarm = await _context.farms.FindAsync(id);

            if(dbFarm == null){
                return BadRequest();
            }

            dbFarm.Name = farm.Name;
            dbFarm.User_Id = farm.User_Id;

            await _context.SaveChangesAsync();

            return Ok(await _context.farms.ToListAsync());
        }

        //Delete an especific farm
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Farm>>> Delete(int id){

            //search the id in the database
            var dbFarm = await _context.farms.FindAsync(id);

            //if the id doesn't exist return an exception
             if(dbFarm == null){
                return BadRequest();
            }

            //remove from de database
            _context.farms.Remove(dbFarm);
            //save the changes
            await _context.SaveChangesAsync();
            //return the list of farms with the changes
            return Ok(await _context.farms.ToListAsync());
        }
    }
}
