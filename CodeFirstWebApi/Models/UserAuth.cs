using CodeFirstWebApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.Models
{
    public class UserAuth
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string PassWord { get; set; }
        public UserRole Role { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
