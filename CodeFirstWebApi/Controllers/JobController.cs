using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly EmployeeDbContext db;

        public JobController(EmployeeDbContext context)
        {

            this.db = context;
        }

        [HttpGet("all-details")]
        public async Task<IActionResult> GetJobDetails()
        {

            var jobDetails = await db.JOb_Details.ToListAsync();
            return Ok(jobDetails);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddJobDetails([FromBody] JobDetailsDto dto)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest("Data Is Not Valid");
            }

            var addData = new Job_Details
            {
                JobTitle = dto.JobTitle,
                Decription = dto.Decription,

            };
            db.JOb_Details.Add(addData);
            await db.SaveChangesAsync();
            return StatusCode(201, addData);
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateDetailsById(int id, [FromBody] JobDetailsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("JobId is not valid!");
            }
            var jobDetails = await db.JOb_Details.FindAsync(id);
            if (jobDetails == null)
                return NotFound($"Data IS not Found");
            jobDetails.JobTitle = dto.JobTitle;
            jobDetails.Decription = dto.Decription;

            db.JOb_Details.Update(jobDetails);
            await db.SaveChangesAsync();
            return Ok(jobDetails);

        }
    }
}
