using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Domain.Common {
    [NotMapped]
    public class SIMCardSummary {
        public string CardName { get; set; }
        public int Count { get; set; } = 0;
    }
}
