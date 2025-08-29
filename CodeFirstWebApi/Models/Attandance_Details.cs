using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.Models
{
    public class Attandance_Details
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public DateTime CheckInDateAndTime { get; set; }

        public DateTime? CheckOutDateAndTime { get; set; }

        public double? TotalHoursWorked { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
