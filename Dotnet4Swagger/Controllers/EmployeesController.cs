using EmployeeManagement.Models;
using EmployeeManagment.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
		{
			try
			{
				var result = await employeeRepository.Search(name, gender);

				if (result.Any())
				{
					return Ok(result);
				}

				return NotFound();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetEmployees()
		{
			try
			{
				return Ok(await employeeRepository.GetEmployees());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			try
			{
				var result = await employeeRepository.GetEmployee(id);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
			}
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
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

				return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
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
					return NotFound($"Employee with Id = {id} not found");
				}

				return await employeeRepository.UpdateEmployee(employee);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<Employee>> DeleteEmployee(int id)
		{
			try
			{
				var employeeToDelete = await employeeRepository.DeleteEmployee(id);
				if (employeeToDelete == null)
				{
					return NotFound($"Employee with Id = {id} not found");
				}
				return employeeToDelete;
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting employee");
			}
		}
	}
}
