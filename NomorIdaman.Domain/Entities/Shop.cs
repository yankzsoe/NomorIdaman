using NomorIdaman.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Domain.Entities {
    public class Shop : AuditEntity {

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
