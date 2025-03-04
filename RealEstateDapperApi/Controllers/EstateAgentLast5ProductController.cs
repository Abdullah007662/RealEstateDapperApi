using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.LastProductRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLast5ProductController : ControllerBase
    {
        private readonly ILast5ProductRepository _lastProductRepository;
        public EstateAgentLast5ProductController(ILast5ProductRepository lastProductRepository)
        {
            _lastProductRepository = lastProductRepository;
        }

        [HttpGet("GetAllLAst5Productsync")]
        public async Task<IActionResult> GetAllLAst5Productsync(int id)
        {
            var values = await _lastProductRepository.GetAllLAst5Productsync(id);
            return Ok(values);
        }
    }
}
