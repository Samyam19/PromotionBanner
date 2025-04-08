using Microsoft.EntityFrameworkCore;
using PromotionBanner.Entities;

namespace PromotionBanner
{
    public class PromitionBannerDbContext : DbContext
    {
        public PromitionBannerDbContext(DbContextOptions<PromitionBannerDbContext> options): base(options) 
        {
        }

        public DbSet<Banner> Banner { get; set; } = null!;
        public DbSet<Company> Company { get; set; } = null!;

    }
}
