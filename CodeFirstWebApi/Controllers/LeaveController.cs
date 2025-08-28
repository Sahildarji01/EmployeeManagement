using CodeFirstWebApi.Data;
using CodeFirstWebApi.Enum;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public LeaveController(EmployeeDbContext context) 
        {
           this.db = context;
        }

        [HttpPost("ApplyLeave")]
        public async Task<IActionResult> ApplyLeave([FromBody] LeaveDto dto)
        {
            if (!ModelState.IsValid) {
                return BadRequest("Data Invalid");
            }

            var employeeExists = await db.Employee_details.FirstOrDefaultAsync(e => e.EmployeeId == dto.EmployeeId);
            if (employeeExists == null)
            {
                return BadRequest($"Employee with ID {dto.EmployeeId} does not exist.");
            }

            var leaveDetails = new Leave_Details
            {
               EmployeeId = dto.EmployeeId,
               LeaveType = dto.LeaveType,
               Reason = dto.LeaveReason,
               StartDate = dto.LeaveStartDate,
               EndDate = dto.LeaveEndDate,
               Status = Enum.LeaveStatus.PENDING,
            };

            db.Leave_Details.Add(leaveDetails);
            await db.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpPut("UpdateLeaveStatus")]
        public async Task<IActionResult> UpdateLeaveDecision([FromBody] LeaveStatusDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var leave = await db.Leave_Details.FirstOrDefaultAsync(l => l.LeaveId == dto.LeaveId);

            if (leave == null)
                return NotFound($"No leave found with ID {dto.LeaveId}");

            switch (dto.Status)
            {
                case LeaveStatus.APPROVED:
                    leave.Status = LeaveStatus.APPROVED;
                    leave.ApprovedBy = dto.ApprovedBy;
                    leave.ApprovedOn = dto.ApprovedOn ?? DateTime.Now;
                    break;

                case LeaveStatus.REJECTED:
                    leave.Status = LeaveStatus.REJECTED;
                    leave.RejectedBy = dto.RejectedBy;
                    leave.RejectedOn = dto.RejectedOn ?? DateTime.Now;
                    break;

                default:
                    return BadRequest("Only Approved or Rejected status is allowed.");
            }

            await db.SaveChangesAsync();

            return Ok(new { message = "Leave decision updated successfully", leave });
        }



    }
}
