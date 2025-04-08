using Microsoft.AspNetCore.Mvc;
using PromotionBanner.DTOs;
using PromotionBanner.Services;

namespace PromotionBanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> PostCompany(CompanyDTO companyDTO)
        {
            await _companyService.AddCompanyAsync(companyDTO);
            return CreatedAtAction(nameof(GetCompany), new { id = companyDTO.CompanyId }, companyDTO);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDTO companyDTO)
        {
            if (id != companyDTO.CompanyId)
                return BadRequest();

            await _companyService.UpdateCompanyAsync(companyDTO);
            return NoContent();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
