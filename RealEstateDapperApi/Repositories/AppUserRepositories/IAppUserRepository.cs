using RealEstateDapperApi.Dtos.AppUserDTO;

namespace RealEstateDapperApi.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDTO> GetAppUserByProductId(int id);
    }
}
