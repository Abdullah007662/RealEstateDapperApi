using RealEstateDapperApi.Dtos.ChartDTO;

namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDTO>> Get5CityForChart();
    }
}
