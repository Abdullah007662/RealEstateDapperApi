using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.ToDoListDTO;
using RealEstateDapperApi.Repositories.ToDoListRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoList()
        {
            var value = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateToDoList(CreateToDoListDTO createToDoListDTO)
        {
            _toDoListRepository.CreateToDoList(createToDoListDTO);
            return Ok("Yapılackalar Listesi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("Yapılackalar Listesi Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateToDoList(UpdateToDoListDTO update)
        {
            _toDoListRepository.UpdateToDoList(update);
            return Ok("Yapılackalar Listesi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDToDoList(int id)
        {
            var value = await _toDoListRepository.GetToDoList(id);
            return Ok(value);
        }

        [HttpPut("UpdateStatus")]
        public IActionResult UpdateToDoListStatus([FromBody] UpdateToDoListDTO update)
        {
            _toDoListRepository.UpdateToDoList(update);
            return Ok(new { success = true, message = "Durum başarılı bir şekilde güncellendi" });
        }
    }
}