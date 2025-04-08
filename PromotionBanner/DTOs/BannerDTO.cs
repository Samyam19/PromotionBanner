namespace PromotionBanner.DTOs
{
    public class BannerDTO
    {
        public int Id { get; set; }
        public required string Header { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public int CompanyId { get; set; }
    }
}
