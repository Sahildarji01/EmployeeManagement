using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttandanceController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public AttandanceController(EmployeeDbContext context)
        {
            this.db = context;
        }

        [HttpPost("checkIn")]
        public async Task<IActionResult> checkIn(int employeeId)
        {

            var employee = await db.Employee_details.FindAsync(employeeId);

            if (employee == null) {

                return NotFound("Employee Not Found");
            }

            var existingAttandance = await db.Attandance_Details
                  .FirstOrDefaultAsync(a => a.EmployeeId == employeeId &&
                                         a.CheckInDateAndTime.Date == DateTime.Today &&
                                         a.CheckOutDateAndTime == null);
            if (existingAttandance != null)
                return BadRequest("Employee already checkIn today.");

            var attandance = new Attandance_Details
            {
                EmployeeId = employeeId,
                CheckInDateAndTime = DateTime.Now
            };

            db.Attandance_Details.Add(attandance);
            await db.SaveChangesAsync();
            return Ok(new{message = "Check In Succesfully."});
        }

        [HttpPut("checkOut")]
        public async Task<IActionResult> checkOut(int attandanceId)
        { 
        
            var attandance = await db.Attandance_Details.FindAsync(attandanceId);

            if (attandance == null)
                return NotFound("Attandance Data Not Found");

            if (attandance.CheckOutDateAndTime != null)
                return BadRequest("Already CheckOut");

            attandance.CheckOutDateAndTime = DateTime.Now;
            attandance.TotalHoursWorked = (attandance.CheckOutDateAndTime.Value - attandance.CheckInDateAndTime).TotalHours;
            await db.SaveChangesAsync();
            return Ok(new { message = "Check-out successful" });
        }

        [HttpGet("all")]
        public async Task<IActionResult> getAllDetails()
        { 
        
            var attandance = await db.Attandance_Details.ToListAsync();
            return Ok(attandance);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> attandanceByEmployeeId(int employeeId)
        {

            var employeeAttandance = await db.Attandance_Details.FindAsync(employeeId);
            if (employeeAttandance == null)
                return NotFound("EmployeeId Incorrect.");

            return Ok(employeeAttandance);
        }
    }
}
