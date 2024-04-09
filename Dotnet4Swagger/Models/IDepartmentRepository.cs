using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagment.Api.Models
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetDepartments();
		Department GetDepartmentById(int departmentId);
	}
}
