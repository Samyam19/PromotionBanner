using Microsoft.AspNetCore.Mvc;
using PromotionBanner.DTOs;
using PromotionBanner.Services;

namespace PromotionBanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        // GET: api/Banner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BannerDTO>>> GetBanners()
        {
            var banners = await _bannerService.GetAllBannersAsync();
            return Ok(banners);
        }

        // GET: api/Banner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BannerDTO>> GetBanner(int id)
        {
            var banner = await _bannerService.GetBannerByIdAsync(id);
            if (banner == null)
                return NotFound();

            return Ok(banner);
        }

        // GET: api/Banner/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<BannerDTO>>> GetActiveBanners()
        {
            var activeBanners = await _bannerService.GetActiveBannersAsync();
            return Ok(activeBanners);
        }

        // GET: api/Banner/active/company/3
        [HttpGet("active/company/{companyId}")]
        public async Task<ActionResult<IEnumerable<BannerDTO>>> GetActiveBannersByCompany(int companyId)
        {
            var activeBanners = await _bannerService.GetActiveBannersByCompanyIdAsync(companyId);
            return Ok(activeBanners);
        }

        // POST: api/Banner
        [HttpPost]
        public async Task<ActionResult<BannerDTO>> PostBanner(BannerDTO bannerDTO)
        {
            await _bannerService.AddBannerAsync(bannerDTO);
            return CreatedAtAction(nameof(GetBanner), new { id = bannerDTO.Id }, bannerDTO);
        }

        // PUT: api/Banner/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(int id, BannerDTO bannerDTO)
        {
            if (id != bannerDTO.Id)
                return BadRequest();

            await _bannerService.UpdateBannerAsync(bannerDTO);
            return NoContent();
        }

        // DELETE: api/Banner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var banner = await _bannerService.GetBannerByIdAsync(id);
            if (banner == null)
                return NotFound();

            await _bannerService.DeleteBannerAsync(id);
            return NoContent();
        }
    }
}
