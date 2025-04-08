using PromotionBanner.DTOs;
using PromotionBanner.Entities;
using PromotionBanner.Repository;

namespace PromotionBanner.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IEnumerable<BannerDTO>> GetAllBannersAsync()
        {
            var banners = await _bannerRepository.GetAllAsync();
            return banners.Select(b => new BannerDTO
            {
                Id = b.Id,
                Header = b.Header,
                Description = b.Description,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                CompanyId = b.CompanyId
            });
        }

        public async Task<BannerDTO?> GetBannerByIdAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner == null) return null;

            return new BannerDTO
            {
                Id = banner.Id,
                Header = banner.Header,
                Description = banner.Description,
                StartDate = banner.StartDate,
                EndDate = banner.EndDate,
                CompanyId = banner.CompanyId
            };
        }

        public async Task<IEnumerable<BannerDTO>> GetActiveBannersAsync()
        {
            var currentDate = DateTime.UtcNow;
            var banners = await _bannerRepository.GetAllAsync();

            return banners
                .Where(b => b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Select(b => new BannerDTO
                {
                    Id = b.Id,
                    Header = b.Header,
                    Description = b.Description,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    CompanyId = b.CompanyId
                });
        }

        public async Task<IEnumerable<BannerDTO>> GetActiveBannersByCompanyIdAsync(int companyId)
        {
            var currentDate = DateTime.UtcNow;
            var banners = await _bannerRepository.GetAllAsync();

            return banners
                .Where(b => b.CompanyId == companyId && b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Select(b => new BannerDTO
                {
                    Id = b.Id,
                    Header = b.Header,
                    Description = b.Description,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    CompanyId = b.CompanyId
                });
        }

        public async Task AddBannerAsync(BannerDTO bannerDTO)
        {
            if (bannerDTO.StartDate >= bannerDTO.EndDate)
                throw new ArgumentException("EndDate must be greater than StartDate.");

            var banner = new Banner
            {
                Header = bannerDTO.Header,
                Description = bannerDTO.Description,
                StartDate = bannerDTO.StartDate,
                EndDate = bannerDTO.EndDate,
                CompanyId = bannerDTO.CompanyId
            };

            await _bannerRepository.AddAsync(banner);
            bannerDTO.Id = banner.Id;
        }

        public async Task UpdateBannerAsync(BannerDTO bannerDTO)
        {
            var existingBanner = await _bannerRepository.GetByIdAsync(bannerDTO.Id);
            if (existingBanner == null)
                throw new ArgumentException("Banner does not exist.");

            if (bannerDTO.StartDate >= bannerDTO.EndDate)
                throw new ArgumentException("EndDate must be greater than StartDate.");

            existingBanner.Header = bannerDTO.Header;
            existingBanner.Description = bannerDTO.Description;
            existingBanner.StartDate = bannerDTO.StartDate;
            existingBanner.EndDate = bannerDTO.EndDate;
            existingBanner.CompanyId = bannerDTO.CompanyId;

            await _bannerRepository.UpdateAsync(existingBanner);
        }

        public async Task DeleteBannerAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner == null)
                throw new ArgumentException("Banner does not exist.");

            await _bannerRepository.DeleteAsync(id);
        }
    }
}
