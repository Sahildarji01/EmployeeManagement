namespace CodeFirstWebApi.Models.DTO
{
    public class AttandanceDto
    {
        public int AttandanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime? CheckOutDateTime { get; set; }
        public double? TotalHoursWorked { get; set; }
    }
}
