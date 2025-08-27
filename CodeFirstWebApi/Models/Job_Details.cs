using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebApi.Models
{
    public class Job_Details
    {
        [Key]
        public int JobId{ get; set; }

        public string JobTitle { get; set; }

        public string Decription { get; set; }
    }
}
