using RealEstateDapperApi.Dtos.PropertyAmenityDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {

        Task<List<ResultAmenityByStatusTrueDTO>> ResultAmenityByStatusTrue(int id);
        Task<List<ResultAmenityByStatusFalseDTO>> ResultAmenityByStatusFalse(int id);
    }
}
