using Microsoft.AspNetCore.Mvc;
using RealEstateDapperUI.Services;

namespace RealEstateDapperUI.ViewComponents.EstateAgent
{
    public class _EstateAgentStatisticPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentStatisticPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            #region Toplam-Ürün-Sayısı
            var responseMessage16 = await client.GetAsync("https://localhost:44397/api/EstateAgentStatisticDashBoard/AllProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.AllProductCount = jsonData16;
            #endregion

            #region Aktif-İlan-Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:44397/api/EstateAgentStatisticDashBoard/ProductCountByStatusTrue?id="+id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveProductCount = jsonData2;
            #endregion

            #region Pasif-İlan-Sayısı
            var responseMessage12 = await client.GetAsync("https://localhost:44397/api/EstateAgentStatisticDashBoard/ProductCountByStatusFalse?id="+id);
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.PassiveProductCount = jsonData12;
            #endregion

            #region Emlakçının-Toplam-İlan-Sayısı
            var responseMessage7 = await client.GetAsync("https://localhost:44397/api/EstateAgentStatisticDashBoard/ProductCountEmployeeId?id="+id);
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.EmployeeByProductCount = jsonData7;
            #endregion

            return View();
        }
    }
}
