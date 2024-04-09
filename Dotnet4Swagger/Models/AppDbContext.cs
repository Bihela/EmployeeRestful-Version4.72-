using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagment.Api.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed Departments Table
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 1, DepartmentName = "IT" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 2, DepartmentName = "Finance" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 3, DepartmentName = "HR" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 4, DepartmentName = "Marketing" });

			// Seed Employee Table
			modelBuilder.Entity<Employee>().HasData(new Employee
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
			modelBuilder.Entity<Employee>().HasData(new Employee
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
			modelBuilder.Entity<Employee>().HasData(new Employee
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
			modelBuilder.Entity<Employee>().HasData(new Employee
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
		}
	}
}
