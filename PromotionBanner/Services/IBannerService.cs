using PromotionBanner.DTOs;

namespace PromotionBanner.Services
{
    public interface IBannerService
    {
        Task<IEnumerable<BannerDTO>> GetAllBannersAsync();
        Task<BannerDTO?> GetBannerByIdAsync(int id);
        Task<IEnumerable<BannerDTO>> GetActiveBannersAsync();
        Task<IEnumerable<BannerDTO>> GetActiveBannersByCompanyIdAsync(int companyId);
        Task AddBannerAsync(BannerDTO bannerDTO);
        Task UpdateBannerAsync(BannerDTO bannerDTO);
        Task DeleteBannerAsync(int id);
    }
}
