using RealEstateDapperApi.Conteiner;
using RealEstateDapperApi.Hubs;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.ProductRepository;
using RealEstateDapperApi.Repositories.ServiceReporsitory;
using RealEstateDapperApi.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddTransient<Context>();
builder.Services.ConteinerDependencies();

// CORS yapýlandýrmasý: Tüm originlerden gelen isteklere izin veriyoruz
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader()
                     .AllowAnyMethod()
                     .SetIsOriginAllowed(_ => true)
                     .AllowCredentials();
    });
});
builder.Services.AddHttpClient();

// SignalR servisini ekle
builder.Services.AddSignalR();

// Diðer servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geliþtirme ortamýnda Swagger'ý etkinleþtir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

// Controller endpoint'leri
app.MapControllers();

// SignalR Hub endpoint'ini tanýmla
app.MapHub<SignalRHub>("signalrhub");

app.Run();
