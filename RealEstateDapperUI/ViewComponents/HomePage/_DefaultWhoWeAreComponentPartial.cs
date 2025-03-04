using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.PopulerLocationDTO;
using RealEstateDapperUI.Dtos.Service;
using RealEstateDapperUI.Dtos.WhoWeAreDTO;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44397/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("https://localhost:44397/api/Services");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetail>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData2);
                ViewBag.Title = value!.Select(x => x.Title).FirstOrDefault();
                ViewBag.SubTitle = value!.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.Description1 = value!.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value!.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}
