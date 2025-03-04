using Dapper;
using RealEstateDapperApi.Dtos.ProductDTO;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.LastProductRepositories;

namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.Last5ProductRepositories
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;

        public Last5ProductRepository(Context context)
        {
            _context = context;
        }

        public  async Task<List<ResultProductDTO>> GetAllLAst5Productsync(int id)
        {
            string query = "SELECT TOP(5) ProductID, Title, Price, City, Disrict, CategoryName, CoverImage,Description, Type, Address, DealOfTheDay,Adverstisement FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID Where EmployeeID=@employeeid ORDER BY ProductID DESC;";
            var paramaters = new DynamicParameters();
            paramaters.Add("employeeid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query,paramaters);
                return values.ToList();
            }
        }
    }
}
