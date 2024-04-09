using System;
using System.Configuration;
using System.Data.Entity;
using EmployeeManagement.Models;

namespace EmployeeManagment.Api.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("name=DBConnection")
		{
			Database.SetInitializer(new AppDbInitializer());
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure your entities here (e.g., entity mappings)
		}
	}

	public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
	{
		protected override void Seed(AppDbContext context)
		{
			base.Seed(context);

			// Seed Departments Table
			context.Departments.Add(new Department { DepartmentId = 1, DepartmentName = "IT" });
			context.Departments.Add(new Department { DepartmentId = 2, DepartmentName = "Finance" });
			context.Departments.Add(new Department { DepartmentId = 3, DepartmentName = "HR" });
			context.Departments.Add(new Department { DepartmentId = 4, DepartmentName = "Marketing" });

			// Seed Employee Table
			context.Employees.Add(new Employee
			{
				EmployeeId = 1,
				FirstName = "John",
				LastName = "Hastings",
				Email = "john@example.com",
				DateOfBirth = new DateTime(1980, 10, 5),
				Gender = Gender.Male,
				DepartmentId = 1,
				PhotoPath = "images/john.jpg"
			});

			context.Employees.Add(new Employee
			{
				EmployeeId = 2,
				FirstName = "Alice",
				LastName = "Smith",
				Email = "alice@example.com",
				DateOfBirth = new DateTime(1990, 5, 15),
				Gender = Gender.Female,
				DepartmentId = 2,
				PhotoPath = "images/alice.jpg"
			});

			context.Employees.Add(new Employee
			{
				EmployeeId = 3,
				FirstName = "Bob",
				LastName = "Johnson",
				Email = "bob@example.com",
				DateOfBirth = new DateTime(1985, 8, 25),
				Gender = Gender.Male,
				DepartmentId = 3,
				PhotoPath = "images/bob.jpg"
			});

			context.Employees.Add(new Employee
			{
				EmployeeId = 4,
				FirstName = "Emily",
				LastName = "Davis",
				Email = "emily@example.com",
				DateOfBirth = new DateTime(1995, 12, 10),
				Gender = Gender.Female,
				DepartmentId = 4,
				PhotoPath = "images/emily.jpg"
			});

			context.SaveChanges();
		}
	}
}
