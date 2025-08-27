using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public EmployeeController(EmployeeDbContext context)
        {
            this.db = context;
        }
        [HttpGet]
        [Route("api/EmployeeController/GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employee = await db.Employee_details.ToListAsync();
            return Ok(employee);
        }
        [HttpGet]
        [Route("api/EmployeeController/GetEmployeeListById")]
        public async Task<IActionResult> GetEmployeeListById(int id)
        {
            var employee = await db.Employee_details.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("api/EmployeeController/CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employee obj)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }

            db.Employee_details.Add(obj);
            await db.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPost]
        [Route("api/EmployeeController/basic-info")]
        public async Task<IActionResult> AddBasicInfo([FromBody] EmployeeBasicInfoDto basicInfoDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest("Data Is Not Valid");
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

        [HttpPut]
        [Route("api/EmployeeController/UpdateEmployeeDetails")]
        public async Task<IActionResult> UpdateEmployeeDetails(int id, Employee obj)
        {

            if (id != obj.EmployeeId)
            {

                return BadRequest("Employee id mismatch!");
            }
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpDelete]
        [Route("api/EmployeeController/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            var employee = db.Employee_details.Find(id);
            if (employee == null)
            {

                return NotFound();
            }
            db.Employee_details.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
