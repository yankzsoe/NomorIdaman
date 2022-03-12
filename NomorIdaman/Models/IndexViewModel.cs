using System.Collections.Generic;

namespace NomorIdaman.WebApplication.Models {
    public class IndexViewModel {
        public int ShopSelected { get; set; }
        public int ProviderSelected { get; set; }

        public IEnumerable<ProviderViewModel> providers { get; set; }
        public IEnumerable<ShopViewModel> shops { get; set; }
        public IEnumerable<SIMCardViewModel> simCards { get; set; }
    }

    public class ProviderViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ShopViewModel {
        public int Id { get; set; }
        public string Code { get; set; }
    }

    public class SIMCardViewModel {
        public string CardNumber { get; set; }
        public string Price { get; set; }
        public int ProviderCardId { get; set; }
        public string ProviderCardName { get; set; }
        public string ShopCode { get; set; }
        public int ShopId { get; set; }
    }
}
