using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.BottomGridDTO;
using RealEstateDapperApi.Repositories.BottomGridRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var liste = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(liste);
        }
        [HttpPost]
        public IActionResult CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDTO);
            return Ok("Veri Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBottomGrid(int id)
        {
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Veri Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBottomGrid(UpdateBottomGridDTO update)
        {
            _bottomGridRepository.UpdateBottomGrid(update);
            return Ok("Veri Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}
