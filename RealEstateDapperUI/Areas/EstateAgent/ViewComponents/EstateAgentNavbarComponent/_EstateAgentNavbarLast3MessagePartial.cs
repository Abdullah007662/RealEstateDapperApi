using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.MessageDTO;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarComponent
{
    [ViewComponent]
    public class _EstateAgentNavbarLast3MessagePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService l_oginService;

        public _EstateAgentNavbarLast3MessagePartial(IHttpClientFactory httpClientFactory, ILoginService l_oginService)
        {
            _httpClientFactory = httpClientFactory;
            this.l_oginService = l_oginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = l_oginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44397/api/Messages?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
