namespace PromotionBanner.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public required string Name { get; set; }

        public ICollection<Banner> Banners { get; set; } = new List<Banner>();
    }
}
