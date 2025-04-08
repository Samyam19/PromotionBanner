using PromotionBanner.DTOs;
using PromotionBanner.Entities;
using PromotionBanner.Repository;

namespace PromotionBanner.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return companies.Select(c => new CompanyDTO
            {
                CompanyId = c.CompanyId,
                Name = c.Name
            });
        }

        public async Task<CompanyDTO?> GetCompanyByIdAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
                return null;

            return new CompanyDTO
            {
                CompanyId = company.CompanyId,
                Name = company.Name
            };
        }

        public async Task AddCompanyAsync(CompanyDTO companyDTO)
        {
            var company = new Company
            {
                Name = companyDTO.Name
            };

            await _companyRepository.AddAsync(company);
            companyDTO.CompanyId = company.CompanyId;
        }

        public async Task UpdateCompanyAsync(CompanyDTO companyDTO)
        {
            var company = new Company
            {
                CompanyId = companyDTO.CompanyId,
                Name = companyDTO.Name
            };

            await _companyRepository.UpdateAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}
