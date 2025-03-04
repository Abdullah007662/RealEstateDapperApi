using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.EmployeeDTO;

namespace RealEstateDapperApi.Repositories.EmployeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync();
        Task CreateEmployee(CreateEmployeeDTO createEmployeeDTO);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        Task<GetByIıDEmployeeDTO> GetEmployee(int id);
    }
}
