using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.Models
{
    public class Department_Details
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string CompanyName { get; set; }
    }
}
