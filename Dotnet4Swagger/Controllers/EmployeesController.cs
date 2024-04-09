using EmployeeManagement.Models;
using EmployeeManagment.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;


namespace EmployeeManagment.Api.Controllers
{
	public class EmployeesController : ApiController
	{
		private readonly IEmployeeRepository employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		[HttpGet]
		[Route("api/Employees/Search")]
		public async Task<IHttpActionResult> Search(string name, Gender? gender)
		{
			try
			{
				var result = await employeeRepository.Search(name, gender);

				if (result != null && result.Any())
				{
					return Ok(result);
				}

				return NotFound();
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpGet]
		[Route("api/Employees")]
		public async Task<IHttpActionResult> GetEmployees()
		{
			try
			{
				var employees = await employeeRepository.GetEmployees();
				return Ok(employees);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpGet]
		[Route("api/Employees/{id:int}")]
		public async Task<IHttpActionResult> GetEmployee(int id)
		{
			try
			{
				var employee = await employeeRepository.GetEmployee(id);
				if (employee == null)
				{
					return NotFound();
				}
				return Ok(employee);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpPost]
		[Route("api/Employees")]
		public async Task<IHttpActionResult> CreateEmployee(Employee employee)
		{
			try
			{
				if (employee == null)
				{
					return BadRequest("Employee object is null");
				}

				var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);

				if (emp != null)
				{
					ModelState.AddModelError("email", "Employee email already in use");
					return BadRequest(ModelState);
				}

				var createdEmployee = await employeeRepository.AddEmployee(employee);

				return CreatedAtRoute("DefaultApi", new { id = createdEmployee.EmployeeId }, createdEmployee);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpPut]
		[Route("api/Employees/{id:int}")]
		public async Task<IHttpActionResult> UpdateEmployee(int id, Employee employee)
		{
			try
			{
				if (id != employee.EmployeeId)
				{
					return BadRequest("Employee ID mismatch");
				}
				var employeeToUpdate = await employeeRepository.GetEmployee(id);

				if (employeeToUpdate == null)
				{
					return NotFound();
				}

				await employeeRepository.UpdateEmployee(employee);
				return Ok(employee);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpDelete]
		[Route("api/Employees/{id:int}")]
		public async Task<IHttpActionResult> DeleteEmployee(int id)
		{
			try
			{
				var employeeToDelete = await employeeRepository.DeleteEmployee(id);
				if (employeeToDelete == null)
				{
					return NotFound();
				}
				return Ok(employeeToDelete);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
