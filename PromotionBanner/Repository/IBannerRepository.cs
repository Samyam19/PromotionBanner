using PromotionBanner.Entities;

namespace PromotionBanner.Repository
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllAsync();
        Task<Banner?> GetByIdAsync(int id);
        Task AddAsync(Banner banner);
        Task UpdateAsync(Banner banner);
        Task DeleteAsync(int id);
    }
}
