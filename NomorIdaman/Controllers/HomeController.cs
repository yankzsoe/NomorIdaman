using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NomorIdaman.Models;
using NomorIdaman.WebApplication.Interface;
using NomorIdaman.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace NomorIdaman.WebApplication.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IBridgeApiSettings _bridgeApiSettings;

        public HomeController(ILogger<HomeController> logger, IBridgeApiSettings bridgeApiSettings) {
            _logger = logger;
            _bridgeApiSettings = bridgeApiSettings;
        }

        public IActionResult Index() {
            var vm = new IndexViewModel();
            using (var httpClient = new HttpClient()) {
                httpClient.BaseAddress = new Uri(_bridgeApiSettings.BaseAPiUrl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                Task<HttpResponseMessage> simCardResponse = httpClient.GetAsync("api/sim-card?keyword=&isActive=true&sortBy=Asc&orderBy=Shop&pageNumber=1&pageSize=10");
                JsonNode simCardNode = JsonNode.Parse(simCardResponse.Result.Content.ReadAsStringAsync().Result.ToString());
                if (simCardNode["succeeded"].GetValue<bool>()) {
                    var simCards = new List<SIMCardViewModel>();
                    JsonNode data = simCardNode["data"];
                    var count = data.AsArray().Count;
                    for (int i = 0; i < count; i++) {
                        var item = new SIMCardViewModel() {
                            ProviderCardId = data[i]["providerCardId"].GetValue<int>(),
                            ProviderCardName = data[i]["providerCardName"].GetValue<string>(),
                            ShopCode = data[i]["shopCode"].GetValue<string>(),
                            ShopId = data[i]["shopId"].GetValue<int>(),
                            CardNumber = data[i]["cardNumber"].GetValue<string>(),
                            Price = data[i]["price"].GetValue<decimal>(),
                        };
                        simCards.Add(item);
                    }
                    vm.simCards = simCards;
                }

                Task<HttpResponseMessage> providerResponse = httpClient.GetAsync("api/provider-card");
                JsonNode providerNode = JsonNode.Parse(providerResponse.Result.Content.ReadAsStringAsync().Result.ToString());
                if (providerNode["succeeded"].GetValue<bool>()) {
                    var providers = new List<ProviderViewModel>();
                    JsonNode data = providerNode["data"];
                    var count = data.AsArray().Count;
                    for (int i = 0; i < count; i++) {
                        var item = new ProviderViewModel() {
                            Id = data[i]["id"].GetValue<int>(),
                            Name = data[i]["name"].GetValue<string>()
                        };
                        providers.Add(item);
                    }
                    vm.providers = providers;
                }

                Task<HttpResponseMessage> shopResponse = httpClient.GetAsync("api/shop");
                JsonNode shopNode = JsonNode.Parse(shopResponse.Result.Content.ReadAsStringAsync().Result.ToString());
                if (shopNode["succeeded"].GetValue<bool>()) {
                    var shops = new List<ShopViewModel>();
                    JsonNode data = shopNode["data"];
                    var count = data.AsArray().Count;
                    for (int i = 0; i < count; i++) {
                        var item = new ShopViewModel() {
                            Code = data[i]["code"].GetValue<string>(),
                            Name = data[i]["name"].GetValue<string>()
                        };
                        shops.Add(item);
                    }
                    vm.shops = shops;
                }
            }

            return View(vm);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}