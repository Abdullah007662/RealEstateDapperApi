using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.PropertyAmenityDTO;

namespace RealEstateDapperUI.ViewComponents.PropertySıngle
{
    public class _PropertyAmenityStatusToTrueByPropertyIdPartials : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusToTrueByPropertyIdPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44397/api/PropertyAmenities/PropertyAmenityTrue?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAmenityByStatusTrueDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
