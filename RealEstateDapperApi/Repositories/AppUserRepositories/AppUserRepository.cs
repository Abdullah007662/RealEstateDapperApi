using Dapper;
using RealEstateDapperApi.Dtos.AppUserDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDTO> GetAppUserByProductId(int id)
        {
            string query = "Select * From AppUser Where UserID=@appuserid";
            var parameters = new DynamicParameters();
            parameters.Add("@appuserid", id);
            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDTO>(query,parameters);
                return values!;

            }
        }
    }
}
