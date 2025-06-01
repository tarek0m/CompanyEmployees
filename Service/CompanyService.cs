using Contracts;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;

        public CompanyService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);

            var companiesDto = companies.Select(c =>
                                               new CompanyDto(c.Id, c.Name ?? "", string.Join(' ', c.Address, c.Country))
                                               ).ToList();

            return companiesDto;
        }
    }
}
