using RealEstateDapperApi.Dtos.ServiceDTO;

namespace RealEstateDapperApi.Repositories.ServiceReporsitory
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync();
        Task CreateService(CreateServiceDTO createServiceDTO);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDTO updateServiceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
