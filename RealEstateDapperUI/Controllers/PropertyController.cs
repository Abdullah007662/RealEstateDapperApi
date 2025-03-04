using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProductDetailsDTO;
using RealEstateDapperUI.Dtos.ProductDTO;

namespace RealEstateDapperUI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//İlkten bir Client oluşturuyoruz.
            var responseMessage = await client.GetAsync("https://localhost:44397/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//Gelen İçeriği String Formatta Oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);// Json Degerini Okuyor ve bizim istedigimiz tablo formatına dönüştüüryor
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> PropertyListWithSeach()
        {
            // TempData değerlerini güvenli şekilde çek
            string? seachKeyValue = TempData["seachKeyValue"] as string;
            string? city = TempData["city"] as string;
            int propertyCategoryId = TempData["propertyCategoryId"] != null ? Convert.ToInt32(TempData["propertyCategoryId"]) : 0;

            // Eğer veriler kaybolmasını istemiyorsan Keep() ile sakla
            TempData.Keep("seachKeyValue");
            TempData.Keep("propertyCategoryId");
            TempData.Keep("city");

            // ViewBag içine atayarak View tarafında da kullanılabilir hale getir
            ViewBag.seachKeyValue = seachKeyValue;
            ViewBag.propertyCategoryId = propertyCategoryId;
            ViewBag.city = city;

            // API çağrısı
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44397/api/Products/ResultProductWithSeachList?seachKeyValue={seachKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSeachListDTO>>(jsonData);
                return View(values);
            }

            return View(new List<ResultProductWithSeachListDTO>());
        }


        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();//İlkten bir Client oluşturuyoruz.
            var responseMessage = await client.GetAsync("https://localhost:44397/api/Products/GetByIdProduct?id=" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();//Gelen İçeriği String Formatta Oku
            var values = JsonConvert.DeserializeObject<ResultProductDTO>(jsonData);// Json Degerini Okuyor ve bizim istedigimiz tablo formatına dönüştüüryor


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44397/api/ProductDetails/GetDetailProduct?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailsIdDTO>(jsonData2);



            ViewBag.Baslık = values!.Title;
            ViewBag.İlanid = values!.ProductID;
            ViewBag.Fiyat = values!.Price;
            ViewBag.Sehir = values!.City;
            ViewBag.İlce = values!.Disrict;
            ViewBag.Adres = values!.Address;
            ViewBag.Türü = values!.Type;
            ViewBag.Acıklama = values!.Description;
            ViewBag.Date = values!.Adverstisement;


            DateTime date1=DateTime.Now;

            DateTime date2=values!.Adverstisement;

            TimeSpan timeSpan=date2-date1;

            int month = timeSpan.Days;


            ViewBag.BanyoSayısı = values2!.BathCount;
            ViewBag.YatakOdasıSayısı = values2!.BedRoomCount;
            ViewBag.Buyuklugu = values2.ProductSize;
            ViewBag.OdaSayısı = values2.RoomCount;
            ViewBag.Garajsayısı = values2.GarageSize;
            ViewBag.Yapımyılı = values2.BuildYear;
            ViewBag.Lokasyon = values2.Location;
            ViewBag.VideoUrl = values2.VideoUrl;
            ViewBag.Tarih = month/30;


            return View(values);


        }
    }
}
