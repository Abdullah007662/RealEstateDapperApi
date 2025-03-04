using RealEstateDapperApi.Dtos.ToDoListDTO;

namespace RealEstateDapperApi.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDTO>> GetAllToDoListAsync();
        Task CreateToDoList(CreateToDoListDTO createToDoListDTO);
        Task DeleteToDoList(int id);
        Task UpdateToDoList(UpdateToDoListDTO updateToDoListDTO);
        Task<GetByIdToDoListDTO> GetToDoList(int id);
        Task UpdateToDoListStatus(UpdateToDoListDTO updateToDoListDTO); // DTO'ya uyumlu hale getirildi
    }
}
