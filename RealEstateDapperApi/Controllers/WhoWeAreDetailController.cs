using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.WhoWeAreDetailsDTO;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.WhoWeAreRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var value = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO) // Bunları asekron işaretlemesekte oluyıo 
        {
            _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDTO);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO update)
        {
            _whoWeAreRepository.UpdateWhoWeAreDetail(update);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
