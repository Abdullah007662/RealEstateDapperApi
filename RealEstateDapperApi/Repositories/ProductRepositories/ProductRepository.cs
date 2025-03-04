using Dapper;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Dtos.ProductDetailDTO;
using RealEstateDapperApi.Dtos.ProductDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductRepository
{

    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            string query = "insert into Product (Title,Price,City,Disrict,ProductCategory,CoverImage,Description,ProductStatus,Type,Address,DealOfTheDay,Adverstisement,EmployeeID) values (@title,@price,@city,@disrict,@productCategory,@coverImage,@description,@productStatus,@type,@address,@dealOfTheDay,@adverstisement,@employeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createProductDTO.Title);
            parameters.Add("@price", createProductDTO.Price);
            parameters.Add("@city", createProductDTO.City);
            parameters.Add("@disrict", createProductDTO.Disrict);
            parameters.Add("@productCategory", createProductDTO.ProductCategory);
            parameters.Add("@coverImage", createProductDTO.CoverImage);
            parameters.Add("@description", createProductDTO.Description);
            parameters.Add("@productStatus", createProductDTO.ProductStatus);
            parameters.Add("@type", createProductDTO.Type);
            parameters.Add("@address", createProductDTO.Address);
            parameters.Add("@dealOfTheDay", createProductDTO.DealOfTheDay);
            parameters.Add("@adverstisement", createProductDTO.Adverstisement);
            parameters.Add("@employeeID", createProductDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLast3ProductDTO>> GetAllLAst3ProductAsync()
        {
            string query = "SELECT TOP 3 ProductID, Title, Price, City, Disrict, CategoryName, CoverImage,Description, Type, Address, DealOfTheDay,Adverstisement FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID ORDER BY ProductID DESC;";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductDTO>> GetAllLAst5Productsync()
        {
            string query = "SELECT TOP 5 ProductID, Title, Price, City, Disrict, CategoryName, CoverImage,Description, Type, Address, DealOfTheDay,Adverstisement FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID ORDER BY ProductID DESC;";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductDTO>> GetAlProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductWithCategoryDTO>> GetAlProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,Disrict,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }
        public async Task<GetProductDetailsIdDTO> GetByDetailProduct(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productid";
            var parameters = new DynamicParameters();
            parameters.Add("@productid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailsIdDTO>(query, parameters);
                return values.FirstOrDefault()!;
            }
        }
        public async Task<GetByIDProductDTO> GetByIdProduct(int id)
        {
            string query = "Select ProductID,Title,Price,City,Disrict,CategoryName,CoverImage,Type,Address,DealOfTheDay,Adverstisement,Description From Product inner join Category on Product.ProductCategory=Category.CategoryID Where ProductID=@productid";
            var parameters = new DynamicParameters();
            parameters.Add("@productid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDProductDTO>(query, parameters);
                return values.FirstOrDefault()!;
            }
        }
        public async Task<GetByIDProductDTO> GetProduct(int id)
        {
            string query = "Select * From Product Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDProductDTO>(query, parameters);
                return values!;
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdverListByEmployeeAsyncFalse(int id)
        {
            string query = "Select ProductID,Title,Price,City,Disrict,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeıd and ProductStatus=0 ";
            var parameters = new DynamicParameters();
            parameters.Add("employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdverListByEmployeeAsyncTrue(int id)
        {
            string query = "Select ProductID,Title,Price,City,Disrict,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeıd and ProductStatus=1 ";
            var parameters = new DynamicParameters();
            parameters.Add("employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,Disrict,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID  where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithSeachListDTO>> ResultProductWithSeachList(string seachKeyValue, int propertyCategoryId, string city)
        {
            // SQL Sorgusu
            string query = "SELECT * FROM Product WHERE Title LIKE @seachKeyValue AND ProductCategory = @propertyCategoryId AND City = @city";

            // Parametreleri oluştur
            var parameters = new DynamicParameters();
            parameters.Add("@seachKeyValue", "%" + seachKeyValue + "%"); // LIKE için % ekledik
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSeachListDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
