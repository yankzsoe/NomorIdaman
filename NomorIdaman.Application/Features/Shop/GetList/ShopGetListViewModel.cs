﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.Shop.Queries.GetList {
    public class ShopGetListViewModel {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
