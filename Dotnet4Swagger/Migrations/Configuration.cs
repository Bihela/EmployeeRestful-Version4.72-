namespace Dotnet4Swagger.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using EmployeeManagement.Models;
	using EmployeeManagment.Api.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManagment.Api.Models.AppDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(EmployeeManagment.Api.Models.AppDbContext context)
		{
			// Seed Departments Table
			context.Departments.AddOrUpdate(
				d => d.DepartmentId,
				new Department { DepartmentId = 1, DepartmentName = "IT" },
				new Department { DepartmentId = 2, DepartmentName = "Finance" },
				new Department { DepartmentId = 3, DepartmentName = "HR" },
				new Department { DepartmentId = 4, DepartmentName = "Marketing" }
			);

			// Seed Employee Table
			context.Employees.AddOrUpdate(
				e => e.EmployeeId,
				new Employee
				{
					EmployeeId = 1,
					FirstName = "John",
					LastName = "Hastings",
					Email = "john@example.com",
					DateOfBirth = new DateTime(1980, 10, 5),
					Gender = Gender.Male,
					DepartmentId = 1,
					PhotoPath = "images/john.jpg"
				},
				new Employee
				{
					EmployeeId = 2,
					FirstName = "Alice",
					LastName = "Smith",
					Email = "alice@example.com",
					DateOfBirth = new DateTime(1990, 5, 15),
					Gender = Gender.Female,
					DepartmentId = 2,
					PhotoPath = "images/alice.jpg"
				},
				new Employee
				{
					EmployeeId = 3,
					FirstName = "Bob",
					LastName = "Johnson",
					Email = "bob@example.com",
					DateOfBirth = new DateTime(1985, 8, 25),
					Gender = Gender.Male,
					DepartmentId = 3,
					PhotoPath = "images/bob.jpg"
				},
				new Employee
				{
					EmployeeId = 4,
					FirstName = "Emily",
					LastName = "Davis",
					Email = "emily@example.com",
					DateOfBirth = new DateTime(1995, 12, 10),
					Gender = Gender.Female,
					DepartmentId = 4,
					PhotoPath = "images/emily.jpg"
				}
			);
		}
	}
}
