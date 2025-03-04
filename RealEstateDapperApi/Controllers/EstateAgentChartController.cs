using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        [HttpGet]
        public  async Task<IActionResult> Chart5City()
        {
            var value=await _chartRepository.Get5CityForChart();
            return Ok(value);
        } 
    }
}
