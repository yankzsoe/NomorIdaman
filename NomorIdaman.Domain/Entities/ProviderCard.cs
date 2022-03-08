using NomorIdaman.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace NomorIdaman.Domain.Entities {
    public class ProviderCard : AuditEntity {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
