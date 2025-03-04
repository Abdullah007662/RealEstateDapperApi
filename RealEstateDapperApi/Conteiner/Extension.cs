using RealEstateDapperApi.Repositories.AppUserRepositories;
using RealEstateDapperApi.Repositories.BottomGridRepository;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.ContactRepositories;
using RealEstateDapperApi.Repositories.EmployeRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.Last5ProductRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.LastProductRepositories;
using RealEstateDapperApi.Repositories.MessageRepositories;
using RealEstateDapperApi.Repositories.PopulerLocationRepositories;
using RealEstateDapperApi.Repositories.ProductImageRepositories;
using RealEstateDapperApi.Repositories.ProductRepository;
using RealEstateDapperApi.Repositories.PropertyAmenityRepositories;
using RealEstateDapperApi.Repositories.ServiceReporsitory;
using RealEstateDapperApi.Repositories.StatisticsRepositories;
using RealEstateDapperApi.Repositories.SubFeatureRepositories;
using RealEstateDapperApi.Repositories.TestimonialRepository;
using RealEstateDapperApi.Repositories.ToDoListRepositories;
using RealEstateDapperApi.Repositories.WhoWeAreRepository;

namespace RealEstateDapperApi.Conteiner
{
    public static class Extension
    {
        public static void ConteinerDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<ICategoryRepository, CategoryRepository>();
            Services.AddTransient<IProductRepository, ProductRepository>();
            Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
            Services.AddTransient<IServiceRepository, ServiceRepository>();
            Services.AddTransient<IBottomGridRepository, BottomGridReporsitory>();
            Services.AddTransient<IPopulerLocationRepository, PopulerLocationRepository>();
            Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            Services.AddTransient<IStatisticsReporsitory, StatisticsRepository>();
            Services.AddTransient<IContactRespository, ContactRepository>();
            Services.AddTransient<IToDoListRepository, ToDoListRepository>();
            Services.AddTransient<IStatisticRepository, StatisticRepository>();
            Services.AddTransient<IChartRepository, ChartRepository>();
            Services.AddTransient<ILast5ProductRepository, Last5ProductRepository>();
            Services.AddTransient<IMessageRepository,MessageRepository>();
            Services.AddTransient<IProductImageRepository,ProductImageRepository>();
            Services.AddTransient<IAppUserRepository,AppUserRepository>();
            Services.AddTransient<IPropertyAmenityRepository,PropertyAmenityRepository>();
            Services.AddTransient<ISubFeatureRepository,SubFeatureRepository>();


        }
    }
}
