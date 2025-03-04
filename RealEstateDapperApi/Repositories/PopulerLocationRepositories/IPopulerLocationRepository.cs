using RealEstateDapperApi.Dtos.BottomGridDTO;
using RealEstateDapperApi.Dtos.PopulerLocationDTO;

namespace RealEstateDapperApi.Repositories.PopulerLocationRepositories
{
    public interface IPopulerLocationRepository
    {
        Task<List<ResultPopulerLocationDTO>> GetAllPopulerLocationAsync();
        Task CreatePopulerLocation(CreatePopulerLocationDTO createPopulerLocationDTO);
        Task DeletePopulerLocation(int id);
        Task UpdatePopulerLocation(UpdatePopulerLocationDTO updatePopulerLocationDTO);
        Task<GetByIDPopulerLocationDTO> GetPopulerLocation(int id);
    }
}
