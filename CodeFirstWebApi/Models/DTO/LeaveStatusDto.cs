using CodeFirstWebApi.Enum;

namespace CodeFirstWebApi.Models.DTO
{
    public class LeaveStatusDto
    {
        public int LeaveId { get; set; }
        public LeaveStatus Status { get; set; }

        public DateTime? ApprovedOn { get; set; }
        public string? ApprovedBy { get; set; }

        public DateTime? RejectedOn { get; set; }
        public string? RejectedBy { get; set; }
    }
}
