using Dapper;
using RealEstateDapperApi.Dtos.ChartDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDTO>> Get5CityForChart()
        {
            string query = "Select Top(5) City,Count(*) as 'CityCount' From Product Group By City order By CityCount Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDTO>(query);
                return values.ToList();
            }
        }
    }
}
