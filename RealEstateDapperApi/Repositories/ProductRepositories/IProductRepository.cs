using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Dtos.ProductDetailDTO;
using RealEstateDapperApi.Dtos.ProductDTO;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAlProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdverListByEmployeeAsyncTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdverListByEmployeeAsyncFalse(int id);
        Task<List<ResultProductWithCategoryDTO>> GetAlProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultProductDTO>> GetAllLAst5Productsync();
        Task<List<ResultLast3ProductDTO>> GetAllLAst3ProductAsync();
        Task<GetByIDProductDTO> GetProduct(int id);
        Task CreateProduct(CreateProductDTO createProductDTO);
        Task<GetByIDProductDTO> GetByIdProduct(int id);
        Task<GetProductDetailsIdDTO> GetByDetailProduct(int id);
        Task<List<ResultProductWithSeachListDTO>>  ResultProductWithSeachList(string seachKeyValue,int propertyCategoryId,string city);
        Task<List<ResultProductWithCategoryDTO>> GetProductDealOfTheDayTrueWithCategoryAsync();



    }
}
