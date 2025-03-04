using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Repositories.CategoryRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _categoryRepository.GetAllCategoryAsync();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO) // Bunları asekron işaretlemesekte oluyıo 
        {
            _categoryRepository.CreateCategory(createCategoryDTO);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO update)
        {
            _categoryRepository.UpdateCategory(update);
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDCategory(int id)
        {
            var value = await _categoryRepository.GetCategory(id);
            return Ok(value);
        }
    }
}
