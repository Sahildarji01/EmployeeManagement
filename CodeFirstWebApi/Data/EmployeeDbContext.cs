using CodeFirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employee_details { get; set; }

        public DbSet<UserAuth> UserAuth { get; set; }

        public DbSet<Leave_Details> Leave_Details { get; set; }

        public DbSet<Attandance_Details> Attandance_Details { get; set; }

        public DbSet<Department_Details> Department_Details  { get; set; }

        public DbSet<Job_Details> JOb_Details { get; set; }
    }
}
