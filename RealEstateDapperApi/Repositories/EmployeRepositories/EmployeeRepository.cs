using Dapper;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.EmployeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values (@name,@title,@mail,@phonenumber,@ımageurl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDTO.Name);
            parameters.Add("@title", createEmployeeDTO.Title);
            parameters.Add("@mail", createEmployeeDTO.Mail);
            parameters.Add("@phonenumber", createEmployeeDTO.PhoneNumber);
            parameters.Add("@ımageurl", createEmployeeDTO.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public  async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIıDEmployeeDTO> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIıDEmployeeDTO>(query, parameters);
                return values!;
            }
        }

        public  async Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            string query = "Update Employee Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phonenumber,ImageUrl=@ımageurl,Status=@status where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDTO.Name);
            parameters.Add("@title", updateEmployeeDTO.Title);
            parameters.Add("@mail", updateEmployeeDTO.Mail);
            parameters.Add("@phonenumber", updateEmployeeDTO.PhoneNumber);
            parameters.Add("@ımageurl", updateEmployeeDTO.ImageUrl);
            parameters.Add("@status", updateEmployeeDTO.Status);
            parameters.Add("@employeeID",updateEmployeeDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
