using Microsoft.EntityFrameworkCore;
using PromotionBanner.Entities;

namespace PromotionBanner.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly PromotionBannerDbContext _context;

        public BannerRepository(PromotionBannerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banner>> GetAllAsync()
        {
            return await _context.Banner.Include(b => b.Company).ToListAsync();
        }

        public async Task<Banner?> GetByIdAsync(int id)
        {
            return await _context.Banner.Include(b => b.Company)
                                         .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Banner banner)
        {
            _context.Banner.Add(banner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Banner banner)
        {
            _context.Banner.Update(banner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var banner = await _context.Banner.FindAsync(id);
            if (banner != null)
            {
                _context.Banner.Remove(banner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
