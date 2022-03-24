using NomorIdaman.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace NomorIdaman.Domain.Entities {
    public class SIMCard : AuditEntity {

        [Required]
        [StringLength(15)]
        public string CardNumber { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsSold { get; set; }

        [Required]
        public int ProviderCardId { get; set; }
        public ProviderCard ProviderCard { get; set; }

        [Required]
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
