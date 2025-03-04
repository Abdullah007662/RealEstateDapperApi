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

// CORS yap�land�rmas�: T�m originlerden gelen isteklere izin veriyoruz
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

// Di�er servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geli�tirme ortam�nda Swagger'� etkinle�tir
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

// SignalR Hub endpoint'ini tan�mla
app.MapHub<SignalRHub>("signalrhub");

app.Run();
