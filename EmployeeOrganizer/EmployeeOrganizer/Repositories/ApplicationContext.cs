using EmployeeOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeOrganizer.Repositories
{
    public class ApplicationContext : DbContext, IRepository<Entity>
    {
        public DbSet<Entity> DbSet { get; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<Employee>().HasQueryFilter(e => e.Active);
            modelBuilder.Entity<Department>().HasQueryFilter(e => e.Active);
            modelBuilder.Entity<Entity>().HasQueryFilter(e => e.Active);
            modelBuilder.Ignore<Entity>();


            // Data seed
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Budapest", ShortName = "BP" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Zalaegerszeg", ShortName = "Zala" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Szeged", ShortName = "SZE" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Szolnok", ShortName = "SZO" });


            modelBuilder.Entity<Rank>().HasData(new Rank { Id = 1, Name = "Architect" });
            modelBuilder.Entity<Rank>().HasData(new Rank { Id = 2, Name = "Software Engineer" });
            modelBuilder.Entity<Rank>().HasData(new Rank { Id = 3, Name = "Scrum Master" });
            modelBuilder.Entity<Rank>().HasData(new Rank { Id = 4, Name = "Project Owner" });
            modelBuilder.Entity<Rank>().HasData(new Rank { Id = 5, Name = "Tech Lead" });

            var password = BCrypt.Net.BCrypt.HashPassword("password");
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "John Doe",
                PhoneNumber = "+36204567897",
                DepartmentId = 1,
                Password = password,
                SuperiorId = null,
                RankId = 1,
                Username = "JoDo",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                Name = "Elizabeth Doe",
                PhoneNumber = "+36704563497",
                DepartmentId = 2,
                Password = password,
                SuperiorId = 1,
                RankId = 2,
                Username = "ElDo",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                Name = "Alice Doe",
                PhoneNumber = "+36204357297",
                DepartmentId = 1,
                Password = password,
                SuperiorId = 1,
                RankId = 3,
                Username = "AlDo",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                Name = "Steve Doe",
                PhoneNumber = "+36704542317",
                DepartmentId = 4,
                Password = password,
                SuperiorId = 1,
                RankId = 5,
                Username = "StDo",
            });
        }
    }
}