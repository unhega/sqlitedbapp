using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Models;
using sqlitedbapp.Services;

namespace sqlitedbapp.Controllers
{
    [Route("api/[controller]")]
    [Produces("applications/json")]
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
    }
}