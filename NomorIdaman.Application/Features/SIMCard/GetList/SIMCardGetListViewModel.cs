﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.SIMCard.Queries.GetList {
    public class SIMCardGetListViewModel {
        public string CardNumber { get; set; }
        public decimal Price{ get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ProviderCardId { get; set; }
        public string ProviderCardName { get; set; }
        public int ShopId { get; set; }
        public string ShopCode { get; set; }
    }
}
