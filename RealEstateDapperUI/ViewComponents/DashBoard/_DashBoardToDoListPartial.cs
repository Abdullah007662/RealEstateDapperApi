using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ToDoListDTO;
using System.Text;

namespace RealEstateDapperUI.ViewComponents.DashBoard
{
    public class _DashBoardToDoListPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashBoardToDoListPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44397/api/ToDoList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}