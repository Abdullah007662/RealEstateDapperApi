using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.SubFeatureDTO;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responeMessage = await client.GetAsync("https://localhost:44397/api/SubFeatures");
            if (responeMessage.IsSuccessStatusCode)
            {
                var jsonData= await responeMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultSubFeatureDTO>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
