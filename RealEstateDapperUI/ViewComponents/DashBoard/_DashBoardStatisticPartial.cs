using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.DashBoard
{
    public class _DashBoardStatisticPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashBoardStatisticPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region Toplam-Ürün-Sayısı
            var responseMessage16 = await client.GetAsync("https://localhost:44397/api/Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData16;
            #endregion

            #region Aktif-Çalışan-Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:44397/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData2;
            #endregion

            #region En-Son-Eklenen-Ürün-Fiyatı
            var responseMessage12 = await client.GetAsync("https://localhost:44397/api/Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData12;
            #endregion

            #region Kategori-Sayısı
            var responseMessage7 = await client.GetAsync("https://localhost:44397/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoruCount = jsonData7;
            #endregion

            return View();
        }
    }
}
