using Microsoft.EntityFrameworkCore;
using PromotionBanner.Entities;

namespace PromotionBanner
{
    public class PromotionBannerDbContext : DbContext
    {
        public PromotionBannerDbContext(DbContextOptions<PromotionBannerDbContext> options): base(options) 
        {
        }

        public DbSet<Banner> Banner { get; set; } = null!;
        public DbSet<Company> Company { get; set; } = null!;

    }
}
