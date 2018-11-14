using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Services;
using sqlitedbapp.Models;
using System.Collections.Generic;

namespace sqlitedbapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController:ControllerBase
    {
        SqliteDbContext dbContext;
        public SessionController(SqliteDbContext dbContext){
            this.dbContext = dbContext;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync(){
            var result = await dbContext.Sessions.ToListAsync() as List<Session>;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id){
            var result = await dbContext.Sessions.SingleAsync(e => e.Id == id) as Session;
            if(result != null) return Ok(result);
            else return NotFound();
        }

        [HttpGet("online")]
        public async Task<IActionResult> GetOnlineAsync(){
            var result = await dbContext.Sessions.Where(e => e.Status == SessionStatus.Online).ToListAsync() as List<Session>;
            if(result.Count > 0) return Ok(result);
            else return NotFound(); 
        }

        // [HttpPost("start")]
        // public async Task<IActionResult> StartSessionAsync(){
        //     return Ok("Result");
        // }
    }
}