using RealEstateDapperApi.Dtos.ProductDTO;

namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.LastProductRepositories
{
    public interface ILast5ProductRepository
    {
        Task<List<ResultProductDTO>> GetAllLAst5Productsync(int id);
    }
}
