using Microsoft.EntityFrameworkCore;
using Student_Portal.Models;

namespace Student_Portal.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DepartmentMaster> departmentMasters { get; set; }

        public DbSet<CourseMaster> courseMasters { get; set; }

        public DbSet<StudentMaster> studentMasters { get; set; }


    }
}
