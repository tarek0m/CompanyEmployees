using Contracts;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;

        public EmployeeService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
            var employees = _repository.Employee.GetAllEmployees(trackChanges);

            var EmployeeDto = employees.Select(e =>
                                                new EmployeeDto(e.Id, e.Name ?? "", e.Age ?? 0, e.Position ?? "")
                                               ).ToList();

            return EmployeeDto;
        }
    }
}
