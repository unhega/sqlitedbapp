using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using sqlitedbapp.Services;

namespace sqlitedbapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController:ControllerBase
    {
        SqliteDbContext dbContext;
        public PricesController(SqliteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await dbContext.Prices.SingleAsync(e => e.Id == id) as Price;
            if(result != null)
                return Ok(result);
            else
                return NotFound(id);
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await dbContext.Prices.ToListAsync() as List<Price>;
            return Ok(result);
        }

        [Route("last")]
        [HttpGet]
        public async Task<IActionResult> GetLastAsync()
        {
            var result = await dbContext.Prices.TakeLast(5).ToListAsync() as List<Price>;
            return Ok(result);
        }
    }
}