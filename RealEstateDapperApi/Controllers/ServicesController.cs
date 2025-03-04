using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Dtos.ServiceDTO;
using RealEstateDapperApi.Repositories.ServiceReporsitory;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public  async Task<IActionResult> GetServiceList()
        {
            var value =await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
        [HttpPost]
        public  IActionResult CreateService(CreateServiceDTO createServiceDTO)
        {
            _serviceRepository.CreateService(createServiceDTO);
            return Ok("Hizmet Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Hizmet Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDTO update)
        {
            _serviceRepository.UpdateService(update);
            return Ok("Hizmet Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDService(int id)
        {
            var value = await _serviceRepository.GetService(id);
            return Ok(value);
        }
    }
}
