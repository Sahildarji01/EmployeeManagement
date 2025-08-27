using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.Models.DTO
{
    public class EmployeeBasicInfoDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string  CreatedBy { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
    }
}
