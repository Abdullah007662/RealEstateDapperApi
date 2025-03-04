using RealEstateDapperApi.Dtos.SubFeatureDTO;

namespace RealEstateDapperApi.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDTO>> GetAllSubFeatureAsync();
    }
}
