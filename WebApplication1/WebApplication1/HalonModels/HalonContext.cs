using System.Data.Entity;

namespace WebApplication1.HalonModels
{
    public class HalonContext : DbContext
    {
        public HalonContext()
            : base("Halon")
        {
        }

        public DbSet<Firefighter> Firefighters { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<County> Counties { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}