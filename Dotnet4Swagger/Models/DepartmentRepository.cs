using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagment.Api.Models
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly AppDbContext _appDbContext;

		public DepartmentRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Department GetDepartmentById(int departmentId)
		{
			return _appDbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
		}

		public IEnumerable<Department> GetDepartments()
		{
			return _appDbContext.Departments.ToList();
		}
	}
}
