using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;

namespace HelpingHands
{
    [Route("api/workerprofile/{StartIndex}/{Count}")]
    [ApiController]

    public class WorkerProfileController : ControllerBase
    {
        private readonly HelpingHandsContext _context;
        public WorkerProfileController(HelpingHandsContext context) 
        {
            _context = context;
        }

        [HttpGet("{StartIndex}/{Count}")]

        public async Task<ActionResult<List<WorkerProfile_CLASS>>> GetWorkerProfiles(int StartIndex, int Count)
        {
            //_context.Database.EnsureCreated();

            var worker_profiles = await _context.WorkerProfile_CLASS!.Skip(StartIndex).Take(Count).ToListAsync();

            return worker_profiles;
        }
    }
}
