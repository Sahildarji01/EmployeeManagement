using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public UserAuthController(EmployeeDbContext context)
        {
            this.db = context;
        }

        [Route("api/UserAuth/Register")]
        [HttpPost]
        public async Task<IActionResult> SetUpPassword([FromBody] SetUpPasswordDto passwordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            var employee = await db.Employee_details
                                   .FirstOrDefaultAsync(e => e.EmailId == passwordDto.EmailId);

            if (employee == null)
            {
                return NotFound("Employee not found with this EmailId");
            }

            var existingUser = await db.UserAuth
                                       .FirstOrDefaultAsync(u => u.EmailId == passwordDto.EmailId);

            if (existingUser != null)
            {
                return BadRequest("Account already activated. Please login!");
            }

            var userAuth = new UserAuth
            {
                EmailId = passwordDto.EmailId,
                PassWord = passwordDto.Password,
                Role = Enum.UserRole.EMPLOYEE,
                EmployeeId = employee.EmployeeId,
                CreatedOn = DateTime.UtcNow,
            };

            db.UserAuth.Add(userAuth);
            await db.SaveChangesAsync();

            return Ok("Password setup successful. You can now login.");
        }

        [Route("api/UserAuth/Login")]
        [HttpGet]
        public async Task<IActionResult> EmployeeLogin([FromQuery] string EmailId, [FromQuery] string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            var userAuth = await db.UserAuth
                                   .FirstOrDefaultAsync(e => e.EmailId == EmailId);

            if (userAuth == null)
            {
                return NotFound("User not found");
            }

            if (userAuth.PassWord != Password)
            {
                return Unauthorized("Incorrect password. Please check it.");
            }

            var response = new
            {
                userAuth.UserId,
                userAuth.EmailId,
                userAuth.Role,
                userAuth.CreatedOn,
                userAuth.EmployeeId
            };

            return Ok(response);
        }
    }
}
