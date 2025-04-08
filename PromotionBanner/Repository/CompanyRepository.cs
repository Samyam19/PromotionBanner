using Microsoft.EntityFrameworkCore;
using PromotionBanner.Entities;

namespace PromotionBanner.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PromotionBannerDbContext _context;

        public CompanyRepository(PromotionBannerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Company
                .Include(c => c.Banners)
                .ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Company
                .Include(c => c.Banners)
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task AddAsync(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
