using System.Data.Entity;
using ProjectsInfo.Entity;

namespace ProjectsInfo.DbContext
{
    public class ProjectContext : System.Data.Entity.DbContext
    {
        public ProjectContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        // Промежуточные таблицы
        public DbSet<ProjectEmployeeInfo> ProjectEmployeeInfo { get; set; }

    }
}