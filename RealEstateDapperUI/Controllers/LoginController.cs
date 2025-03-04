using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperUI.Dtos.LoginDTO;
using RealEstateDapperUI.Models;
using RealEstateDapperUI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstateDapperUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoginService _loginService;

        public LoginController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDTO createLoginDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDTO), Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44397/api/Login", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Token))
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadToken(tokenModel.Token) as JwtSecurityToken; // ✅ DÜZELTME: Cast işlemi yapıldı
                    if (jwtToken != null)
                    {
                        var claims = jwtToken.Claims.ToList(); // ✅ Artık `Claims` özelliğine erişebiliriz

                        claims.Add(new Claim("realEstatToken", tokenModel.Token));

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Employee");
                    }
                }
            }

            return View();
        }
    }
}
