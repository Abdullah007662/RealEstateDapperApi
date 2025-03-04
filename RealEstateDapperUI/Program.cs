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

// ?? Hata yönetimi ve güvenlik ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hatalarý yönlendirmek için
    app.UseHsts(); // HTTPS kullanýmý için (üretimde önerilir)
}

app.UseHttpsRedirection(); // HTTP isteklerini HTTPS'e yönlendir
app.UseStaticFiles(); // wwwroot içindeki statik dosyalara eriþim saðlar

app.UseRouting(); // Routing mekanizmasýný etkinleþtir
app.UseAuthentication();
app.UseAuthorization(); // Yetkilendirme iþlemlerini devreye al

// ?? Route tanýmlamalarý (UseEndpoints yerine doðrudan MapControllerRoute kullanýlýyor)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ?? Areas için özel route tanýmlamasý (Bölgeleri desteklemek için)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// ?? Uygulamayý baþlat
app.Run();
