using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.WhoWeAreDetailsDTO;
using RealEstateDapperApi.Dtos.WhoWeAreDTO;

namespace RealEstateDapperApi.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        Task DeleteWhoWeAreDetail(int id);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO);
        Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
    }
}
