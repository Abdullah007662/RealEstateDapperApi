using Dapper;
using RealEstateDapperApi.Dtos.ToDoListDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;
        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateToDoList(CreateToDoListDTO createToDoListDTO)
        {
            string query = "INSERT INTO ToDoList (Description, ToDoListStatus) VALUES (@Description, @ToDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", createToDoListDTO.Description);
            parameters.Add("@ToDoListStatus", createToDoListDTO.ToDoListStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteToDoList(int id)
        {
            string query = "DELETE FROM ToDoList WHERE ToDoListID = @ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDTO>> GetAllToDoListAsync()
        {
            string query = "SELECT * FROM ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdToDoListDTO> GetToDoList(int id)
        {
            string query = "SELECT * FROM ToDoList WHERE ToDoListID = @ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdToDoListDTO>(query, parameters);
                return values!;
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDTO updateToDoListDTO)
        {
            string query = "UPDATE ToDoList SET Description = @Description, ToDoListStatus = @ToDoListStatus WHERE ToDoListID = @ToDoListID";

            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", updateToDoListDTO.ToDoListID);
            parameters.Add("@Description", updateToDoListDTO.Description);
            parameters.Add("@ToDoListStatus", updateToDoListDTO.ToDoListStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateToDoListStatus(UpdateToDoListDTO updateToDoListDTO)
        {
            string query = "UPDATE ToDoList SET ToDoListStatus = @ToDoListStatus WHERE ToDoListID = @ToDoListID";

            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", updateToDoListDTO.ToDoListID);
            parameters.Add("@ToDoListStatus", updateToDoListDTO.ToDoListStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
