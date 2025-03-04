using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.PropertyAmenityRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }
        [HttpGet("PropertyAmenityTrue")]
        public async Task<IActionResult> PropertyAmenityTrue(int id)
        {
            var values= await _propertyAmenityRepository.ResultAmenityByStatusTrue(id);
            return Ok(values);
        }
        [HttpGet("PropertyAmenityFalse")]
        public async Task<IActionResult> PropertyAmenityFalse(int id)
        {
            var values = await _propertyAmenityRepository.ResultAmenityByStatusFalse(id);
            return Ok(values);
        }
    }
}
