using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using RealEstateDapperUI.Models;
using RealEstateDapperUI.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettingsKey"));
builder.Services.AddScoped<ApiSettings>();
builder.Services.AddHttpClient("BaseClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettingsKey:BaseUrl"]!);
});
// ?? Servisleri ekle
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LogoutPath= "/Login/LogOut";
    opt.AccessDeniedPath = "/Pages/AccesDenied/";
    opt.Cookie.HttpOnly=true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "RealEstateJwt";
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ?? Hata y�netimi ve g�venlik ayarlar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hatalar� y�nlendirmek i�in
    app.UseHsts(); // HTTPS kullan�m� i�in (�retimde �nerilir)
}

app.UseHttpsRedirection(); // HTTP isteklerini HTTPS'e y�nlendir
app.UseStaticFiles(); // wwwroot i�indeki statik dosyalara eri�im sa�lar

app.UseRouting(); // Routing mekanizmas�n� etkinle�tir
app.UseAuthentication();
app.UseAuthorization(); // Yetkilendirme i�lemlerini devreye al

// ?? Route tan�mlamalar� (UseEndpoints yerine do�rudan MapControllerRoute kullan�l�yor)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ?? Areas i�in �zel route tan�mlamas� (B�lgeleri desteklemek i�in)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// ?? Uygulamay� ba�lat
app.Run();
