using CodeFirstWebApi.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.Models
{
    public class Leave_Details
    {
        [Key]
        public int LeaveId { get; set; }

        [Required]
        public LeaveType LeaveType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public LeaveStatus Status { get; set; }  

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
