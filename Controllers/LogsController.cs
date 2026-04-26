//using LogPortalBackend.Data;
//using LogPortalBackend.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace LogPortalBackend.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LogsController : ControllerBase
//    {
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogPortalBackend.Data;
using LogPortalBackend.Models;

namespace LogPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddLog(log log)
        {
            log.Timestamp = DateTime.Now;
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return Ok(log);
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            return Ok(await _context.Logs.ToListAsync());
        }

        [HttpGet("anomalies")]
        public async Task<IActionResult> GetAnomalies()
        {
            var anomalies = await _context.Logs
                .Where(l => l.Level == "ERROR")
                .ToListAsync();

            return Ok(anomalies);
        }
    }
}