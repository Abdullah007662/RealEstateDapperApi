using RealEstateDapperApi.Dtos.BottomGridDTO;
using RealEstateDapperApi.Dtos.ServiceDTO;

namespace RealEstateDapperApi.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync();
        Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO);
        Task<GetByIDBottomGridDTO> GetBottomGrid(int id);
    }
}
