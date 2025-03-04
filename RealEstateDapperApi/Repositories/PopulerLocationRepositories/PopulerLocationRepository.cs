using Dapper;
using RealEstateDapperApi.Dtos.BottomGridDTO;
using RealEstateDapperApi.Dtos.PopulerLocationDTO;
using RealEstateDapperApi.Dtos.ServiceDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.PopulerLocationRepositories
{
    public class PopulerLocationRepository : IPopulerLocationRepository
    {
        private readonly Context _context;

        public PopulerLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopulerLocation(CreatePopulerLocationDTO createPopulerLocationDTO)
        {
            string query = "insert into PopulerLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopulerLocationDTO.CityName);
            parameters.Add("@imageUrl", createPopulerLocationDTO.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public  async Task DeletePopulerLocation(int id)
        {
            string query = "Delete From PopulerLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopulerLocationDTO>> GetAllPopulerLocationAsync()
        {
            string query = "Select * From PopulerLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopulerLocationDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopulerLocationDTO> GetPopulerLocation(int id)
        {
            string query = "Select * From PopulerLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopulerLocationDTO>(query, parameters);
                return values!;
            }
        }

        public async Task UpdatePopulerLocation(UpdatePopulerLocationDTO updatePopulerLocationDTO)
        {
            string query = "Update PopulerLocation Set CityName=@cityName,ImageUrl=@imageUrl where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopulerLocationDTO.CityName);
            parameters.Add("@imageUrl", updatePopulerLocationDTO.ImageUrl);
            parameters.Add("@locationID", updatePopulerLocationDTO.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}


