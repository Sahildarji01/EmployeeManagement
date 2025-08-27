using CodeFirstWebApi.Data;
using CodeFirstWebApi.Models;
using CodeFirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext db;

        public DepartmentController(EmployeeDbContext context)
        {
            this.db = context;
        }


        [Route("api/Depatment-details")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentDetails() {

            var department = await db.Department_Details.ToListAsync();
            return Ok(department);
        }

        [Route("api/DepartmentController/add-details")]
        [HttpPost]
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

        [Route("api/DepartmentController/update-details")]
        [HttpPut]
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

        [Route("api/DepartmentController/delete-details")]
        [HttpDelete]
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
