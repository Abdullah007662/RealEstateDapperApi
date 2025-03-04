using RealEstateDapperApi.Dtos.CategoryDTO;

namespace RealEstateDapperApi.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
        Task CreateCategory(CreateCategoryDTO createCategoryDTO);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDTO updateCategory);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
