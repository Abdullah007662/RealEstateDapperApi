using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.EmployeRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var value = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDTO createEmployeeDTO) // Bunları asekron işaretlemesekte oluyıo 
        {
            _employeeRepository.CreateEmployee(createEmployeeDTO);
            return Ok("Çalışan Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("Çalışan Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateEmployee(UpdateEmployeeDTO update)
        {
            _employeeRepository.UpdateEmployee(update);
            return Ok("Çalışan Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }
    }
}
