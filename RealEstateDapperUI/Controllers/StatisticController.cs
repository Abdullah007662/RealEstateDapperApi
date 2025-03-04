using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region Aktif-Kategori-Sayısı
            var responseMessage = await client.GetAsync("https://localhost:44397/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion
            #region Aktif-Çalışan-Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:44397/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData2;
            #endregion
            #region Toplam-Daire-Sayısı
            var responseMessage3 = await client.GetAsync("https://localhost:44397/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonData3;
            #endregion
            #region Ortalama-satılık-ürün-Fiyatı
            var responseMesaage4 = await client.GetAsync("https://localhost:44397/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMesaage4.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonData4;
            #endregion



            #region Ortalama-kiralık-ürün-Fiyatı
            var responseMessage5 = await client.GetAsync("https://localhost:44397/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceBySale = jsonData5;
            #endregion
            #region Ortalama-Oda-Sayısı
            var responseMessage6 = await client.GetAsync("https://localhost:44397/api/Statistics/AverangeRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.AverangeRoomCount = jsonData6;
            #endregion
            #region Kategori-Sayısı
            var responseMessage7 = await client.GetAsync("https://localhost:44397/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoruCount = jsonData7;
            #endregion
            #region Kategoride-bulunan-en-çok-ürün-Adı
            var responseMessage8 = await client.GetAsync("https://localhost:44397/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData8;
            #endregion


            #region En-Fazla-Ürün-Bulunan-İl
            var responseMessage9 = await client.GetAsync("https://localhost:44397/api/Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData9;
            #endregion
            #region Kaç-Farklı-İl
            var responseMessage10 = await client.GetAsync("https://localhost:44397/api/Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData10;
            #endregion
            #region En-Fazla-Satış-Yapan-Çalışanımız
            var responseMessage11 = await client.GetAsync("https://localhost:44397/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData11;
            #endregion
            #region En-Son-Eklenen-Ürün-Fiyatı
            var responseMessage12 = await client.GetAsync("https://localhost:44397/api/Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData12;
            #endregion

            #region En-Yeni-Evin-Yaşı
            var responseMessage13 = await client.GetAsync("https://localhost:44397/api/Statistics/NewestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonData13;
            #endregion
            #region En-Yaşlı-Evin-Yaşı
            var reponseMessage14 = await client.GetAsync("https://localhost:44397/api/Statistics/OldestBuildingYear");
            var jsonData14 = await reponseMessage14.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonData14;
            #endregion
            #region Pasif-Kategori-Sayısı
            var reponseMessage15 = await client.GetAsync("https://localhost:44397/api/Statistics/PassiveCategoryCount");
            var jsonData15 = await reponseMessage15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonData15;
            #endregion
            #region Toplam-Ürün-Sayısı
            var responseMessage16 = await client.GetAsync("https://localhost:44397/api/Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData16;
            #endregion



            return View();
        }
    }
}
