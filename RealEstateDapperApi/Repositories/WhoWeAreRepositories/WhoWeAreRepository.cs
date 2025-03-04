using Dapper;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.WhoWeAreDetailsDTO;
using RealEstateDapperApi.Dtos.WhoWeAreDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) values (@title,@subTitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDTO.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDTO.SubTitle);
            parameters.Add("@description1", createWhoWeAreDetailDTO.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDTO.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whowearedetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDTO>(query, parameters);
                return values!;
            }
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,SubTitle=@subTitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoWeareDetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDTO.Title);
            parameters.Add("@subTitle", updateWhoWeAreDetailDTO.SubTitle);
            parameters.Add("@description1", updateWhoWeAreDetailDTO.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDTO.Description2);
            parameters.Add("@whoWeareDetailid", updateWhoWeAreDetailDTO.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
