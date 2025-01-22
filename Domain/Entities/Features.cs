using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Features
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActiveFeature { get; set; }
        [ForeignKey("Pricing")]
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
    }
}
