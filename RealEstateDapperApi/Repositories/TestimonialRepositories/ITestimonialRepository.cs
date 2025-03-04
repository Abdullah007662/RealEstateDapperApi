using RealEstateDapperApi.Dtos.ServiceDTO;
using RealEstateDapperApi.Dtos.TestimonialDTO;

namespace RealEstateDapperApi.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync();
    }
}
