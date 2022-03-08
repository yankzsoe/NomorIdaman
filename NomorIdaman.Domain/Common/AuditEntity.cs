using System;
using System.ComponentModel.DataAnnotations;

namespace NomorIdaman.Domain.Common {
    public class AuditEntity : BaseEntity {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}