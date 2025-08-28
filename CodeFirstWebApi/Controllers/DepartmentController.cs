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
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public DepartmentController(EmployeeDbContext context)
        {
            this.db = context;
        }


        [HttpGet("departmnet-details")]
        public async Task<IActionResult> GetDepartmentDetails() {

            var department = await db.Department_Details.ToListAsync();
            return Ok(department);
        }

        [HttpPost("add-details")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDetailsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = new Department_Details
            {
                DepartmentName = dto.DepartmentName,
                CompanyName = dto.CompanyName
            };

            db.Department_Details.Add(department);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartmentDetails), new { id = department.DepartmentId }, department);
        }

        [HttpPut("update-details")]
        public async Task<IActionResult> UpdateDepartmentDetailsById(int id ,[FromBody]DepartmentDetailsDto details){
            if (!ModelState.IsValid) { 
                return BadRequest("DepartmentId is not valid!");
            }

            var departmentdetails = await db.Department_Details.FindAsync(id);
            if (departmentdetails == null) 
                return NotFound($"Department with Id {id} not found.");

            departmentdetails.DepartmentName = details.DepartmentName;
            departmentdetails.CompanyName = details.CompanyName;

            db.Department_Details.Update(departmentdetails);
            await db.SaveChangesAsync();

            return Ok(departmentdetails);

            }

        [HttpDelete("remove-department")]
        public async Task<IActionResult> deleteDetailsById(int id) {


            var removeDetails = await db.Department_Details.FindAsync(id);

            if (removeDetails == null) {

                return NotFound($"Id is {id} not Found");
            }

            db.Department_Details.Remove(removeDetails);
            await db.SaveChangesAsync();

            return Ok(removeDetails);
        }
    }
}
