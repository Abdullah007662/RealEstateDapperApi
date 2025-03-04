﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProductDTO;

namespace RealEstateDapperUI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//İlkten bir Client oluşturuyoruz.
            var responseMessage = await client.GetAsync("https://localhost:44397/api/Products/GetProductDealOfTheDayTrueWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//Gelen İçeriği String Formatta Oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);// Json Degerini Okuyor ve bizim istedigimiz tablo formatına dönüştüüryor
                return View(values);
            }
            return View();
        }
    }
}
