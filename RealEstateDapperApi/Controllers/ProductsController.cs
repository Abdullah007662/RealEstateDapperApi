using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ProductDTO;
using RealEstateDapperApi.Repositories.ProductRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var value = await _productRepository.GetAlProductAsync();
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var value = await _productRepository.GetAlProductWithCategoryAsync();
            return Ok(value);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public IActionResult ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Durumu Güncellendi");
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public IActionResult ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Durumu Güncellendi");
        }
        [HttpGet("GetAllLAst5Productsync")]
        public async Task<IActionResult> GetAllLAst5Productsync()
        {
            var value = await _productRepository.GetAllLAst5Productsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDProduct(int id)
        {
            var value = await _productRepository.GetProduct(id);
            return Ok(value);
        }
        [HttpGet("ProductAdvertsListByEmployeeTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeTrue(int id)
        {
             var values=await _productRepository.GetProductAdverListByEmployeeAsyncTrue(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeFalse(int id)
        {
            var values = await _productRepository.GetProductAdverListByEmployeeAsyncFalse(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productRepository.CreateProduct(createProductDTO);
            return Ok("İlan Başarılı Bir Şekilde Eklendi");
        }
        [HttpGet("GetByIdProduct")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var values = await _productRepository.GetByIdProduct(id);
            return Ok(values);
        }
        [HttpGet("ResultProductWithSeachList")]
        public async Task<IActionResult> ResultProductWithSeachList(string seachKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSeachList(seachKeyValue,propertyCategoryId,city);
            return Ok(values);
        }
        [HttpGet("GetProductDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductDealOfTheDayTrueWithCategory()
        {
            return Ok(await _productRepository.GetProductDealOfTheDayTrueWithCategoryAsync());
        }
        [HttpGet("GetAllLAst3ProductAsync")]
        public async Task<IActionResult> GetAllLAst3ProductAsync()
        {
            var values= await _productRepository.GetAllLAst3ProductAsync();
            return Ok(values);
        }
    }
}
