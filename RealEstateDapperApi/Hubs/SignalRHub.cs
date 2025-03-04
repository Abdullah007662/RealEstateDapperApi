using Microsoft.AspNetCore.SignalR;

namespace RealEstateDapperApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage7 = await client.GetAsync("https://localhost:44397/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiverCategoryCount", jsonData7);
        }
    }
}
