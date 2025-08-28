using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public EmployeeController(EmployeeDbContext context)
        {
            this.db = context;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employees = await db.Employee_details.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("GetEmployeeListById/{EmployeeId}")]
        public async Task<IActionResult> GetEmployeeListById(int EmployeeId)
        {
            var employee = await db.Employee_details.FindAsync(EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }

            db.Employee_details.Add(obj);
            await db.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPost("basic-info")]
        public async Task<IActionResult> AddBasicInfo([FromBody] EmployeeBasicInfoDto basicInfoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            var basicInfo = new Employee
            {
                FullName = basicInfoDto.FullName,
                EmailId = basicInfoDto.EmailId,
                PhoneNumber = basicInfoDto.PhoneNumber,
                DateOfBirth = basicInfoDto.DateOfBirth,
                JoiningDate = basicInfoDto.JoiningDate,
                CreatedBy = basicInfoDto.CreatedBy,
                DepartmentId = basicInfoDto.DepartmentId,
                JobId = basicInfoDto.JobId,
            };

            db.Employee_details.Add(basicInfo);
            await db.SaveChangesAsync();

            return Ok(basicInfo);
        }

        [HttpPut("UpdateEmployeeDetails/{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployeeDetails(int EmployeeId, [FromBody] Employee obj)
        {
            if (EmployeeId != obj.EmployeeId)
            {
                return BadRequest("Employee id mismatch!");
            }

            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpDelete("DeleteEmployee/{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            var employee = await db.Employee_details.FindAsync(EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee_details.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut("UpdateProfile/{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployeeProfile(int EmployeeId, [FromBody] EmployeeProfileDto profileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var employee = await db.Employee_details.FindAsync(EmployeeId);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.FullName = profileDto.FullName;
            employee.PhoneNumber = profileDto.PhoneNumber;
            employee.DateOfBirth = profileDto.DateOfBirth;

            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(new
            {
                Message = "Profile updated successfully",
                employee.EmployeeId,
                employee.FullName,
                employee.PhoneNumber,
                employee.DateOfBirth
            });
        }
    }
}
