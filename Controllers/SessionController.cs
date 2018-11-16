using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbapp.Services;
using sqlitedbapp.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace sqlitedbapp.Controllers
{
    [ApiController]
    // [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        SqliteDbContext dbContext;
        ILogger logger;
        public SessionController(SqliteDbContext dbContext, ILogger<SessionController> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await dbContext.Sessions.ToListAsync() as List<Session>;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await dbContext.Sessions.SingleAsync(e => e.Id == id) as Session;
            if (result != null) return Ok(result);
            else return NotFound();
        }

        [HttpGet("online")]
        public async Task<IActionResult> GetOnlineAsync()
        {
            var result = await dbContext.Sessions.Where(e => e.Status == SessionStatus.Online).ToListAsync() as List<Session>;
            if (result.Count > 0) return Ok(result);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSessionAsync([FromBody] Session session)
        {
            // logger.LogInformation("Got session data");
            // В будущем нужно поставить какую-то логику помимо валидации по модели, если вообще нужно
            // Полученная модель внутри себя имеет только Name и Comment, ее нужно донаполнить

            await dbContext.Sessions.AddAsync(session);
            return Ok();
        }
    }
}