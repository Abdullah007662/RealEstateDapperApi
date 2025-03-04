using RealEstateDapperApi.Dtos.ProductImageDTO;

namespace RealEstateDapperApi.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<ResultProductImageDTO>> GetProductImageId(int id);
    }
}
