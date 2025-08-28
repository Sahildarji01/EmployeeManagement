namespace CodeFirstWebApi.Models.DTO
{
    public class EmployeeProfileDto
    {
        public string FullName { get; set; }
        public int  PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
