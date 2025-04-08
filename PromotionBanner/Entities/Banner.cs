using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionBanner.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public required string Header { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
