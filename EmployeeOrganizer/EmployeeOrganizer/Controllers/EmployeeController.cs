using EmployeeOrganizer.DTOs;
using EmployeeOrganizer.Models;
using EmployeeOrganizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeRequestDTO createEmployeeRequest)
        {
            var employee = await _employeeService.AddAsync(createEmployeeRequest);
            if (employee == null)
            {
                return BadRequest("Something went wrong with saving the employee");
            }

            return Created("", employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
                return Ok();

            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateAsync(employee);
            if (updatedEmployee == null)
            {
                return BadRequest("Error with updating the employee");
            }
            return Ok(updatedEmployee);
        }

    }
}
