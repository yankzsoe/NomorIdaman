using Microsoft.Extensions.Configuration;
using NomorIdaman.WebApplication.Interface;

namespace NomorIdaman.WebApplication.Services {
    public class BridgeApiSettingsService : IBridgeApiSettings {

        private readonly IConfiguration _configuration;

        public BridgeApiSettingsService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string BaseAPiUrl => _configuration["BaseApiUrl"];
    }
}
