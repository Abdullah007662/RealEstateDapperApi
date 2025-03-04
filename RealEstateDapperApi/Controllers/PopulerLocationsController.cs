using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.PopulerLocationDTO;
using RealEstateDapperApi.Dtos.ServiceDTO;
using RealEstateDapperApi.Repositories.PopulerLocationRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulerLocationsController : ControllerBase
    {
        private readonly IPopulerLocationRepository _populerLocationRepository;

        public PopulerLocationsController(IPopulerLocationRepository populerLocationRepository)
        {
            _populerLocationRepository = populerLocationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopulerLocationList()
        {
            var liste = await _populerLocationRepository.GetAllPopulerLocationAsync();
            return Ok(liste);
        }
        [HttpPost]
        public IActionResult CreateLocation(CreatePopulerLocationDTO   createPopulerLocationDTO)
        {
            _populerLocationRepository.CreatePopulerLocation(createPopulerLocationDTO);
            return Ok("Lokasyon Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            _populerLocationRepository.DeletePopulerLocation(id);
            return Ok("Lokasyon Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateLocation(UpdatePopulerLocationDTO update)
        {
            _populerLocationRepository.UpdatePopulerLocation(update);
            return Ok("Lokasyon Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDLocation(int id)
        {
            var value = await _populerLocationRepository.GetPopulerLocation(id);
            return Ok(value);
        }
    }
}
