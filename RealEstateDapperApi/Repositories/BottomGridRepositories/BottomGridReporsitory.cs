using Dapper;
using RealEstateDapperApi.Dtos.BottomGridDTO;
using RealEstateDapperApi.Dtos.ProductDTO;
using RealEstateDapperApi.Dtos.ServiceDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.BottomGridRepository
{
    public class BottomGridReporsitory : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridReporsitory(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createBottomGridDTO.Icon);
            parameters.Add("@title", createBottomGridDTO.Title);
            parameters.Add("@description", createBottomGridDTO.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDBottomGridDTO> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDBottomGridDTO>(query, parameters);
                return values!;
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            string query = "Update BottomGrid Set Title=@title,Description=@description,Icon=@icon where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateBottomGridDTO.Title);
            parameters.Add("@bottomGridID", updateBottomGridDTO.BottomGridID);
            parameters.Add("@icon", updateBottomGridDTO.Icon);
            parameters.Add("@description", updateBottomGridDTO.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
