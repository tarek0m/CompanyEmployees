using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeesController(IServiceManager service)
        {
            _serviceManager = service;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _serviceManager.EmployeeService.GetAllEmployees(trackChanges: false);

                return Ok(employees);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
