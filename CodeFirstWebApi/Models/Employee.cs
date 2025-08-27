using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly JoiningDate { get; set; }
        public int DepartmentId { get; set; }
        public Department_Details Department { get; set; }
        public int JobId { get; set; }
        public Job_Details Job { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public UserAuth UserAuth { get; set; }
        public ICollection<Attandance_Details> Attendances { get; set; }
        public ICollection<Leave_Details> Leaves { get; set; }


    }
}
