using CodeFirstWebApi.Enum;

namespace CodeFirstWebApi.Models.DTO
{
    public class LeaveDto
    {
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string LeaveReason { get; set; }
        public DateOnly LeaveStartDate { get; set; }
        public DateOnly LeaveEndDate { get; set; }

    }
}
