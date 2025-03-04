using Dapper;
using RealEstateDapperApi.Dtos.ProductImageDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductImageDTO>> GetProductImageId(int id)
        {
            string query = "Select * From ProductImage Where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection =_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultProductImageDTO>(query,parameters);
                return values.ToList();
            }
        }
    }
}
