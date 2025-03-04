using Dapper;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsReporsitory
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee Where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product where Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) From Product where Type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) From Product where Type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }
        //Select Avg(RoomCount) From ProductDetails

        public int AverangeRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category CategoryName";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select  Top(1)City,Count(*) as 'ilan_Sayısı' From Product Group By City order by [ilan_Sayısı] Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City))  from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values!;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select Name,count(*) 'product_Count' from Product Inner join Employee on Product.EmployeeID=Employee.EmployeeID group by Name Order By product_Count desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price from Product order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values!;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear from ProductDetails order by BuildYear desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear from ProductDetails order by BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values!;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values!;
            }
        }
    }
}
