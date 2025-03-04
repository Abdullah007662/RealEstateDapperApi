using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ContactDTO;
using RealEstateDapperApi.Dtos.PopulerLocationDTO;
using RealEstateDapperApi.Repositories.ContactRepositories;
using RealEstateDapperApi.Repositories.PopulerLocationRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRespository _contactRespository;

        public ContactController(IContactRespository contactRespository)
        {
            _contactRespository = contactRespository;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var liste = await _contactRespository.GetAllContactAsync();
            return Ok(liste);
        }
        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var liste = await _contactRespository.GetLast4ContactAsync();
            return Ok(liste);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            _contactRespository.CreateContact(createContactDTO);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactRespository.DeleteContact(id);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO update)
        {
            _contactRespository.UpdateContact(update);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDContact(int id)
        {
            var value = await _contactRespository.GetByIDContact(id);
            return Ok(value);
        }
    }
}
