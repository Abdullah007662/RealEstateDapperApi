using Dapper;
using RealEstateDapperApi.Dtos.PropertyAmenityDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAmenityByStatusFalseDTO>> ResultAmenityByStatusFalse(int id)
        {
            string query = "Select PropertyAmenityID,Title From PropertyAmenity Inner join Amenity On Amenity.AmenityId=PropertyAmenity.AmenityID Where PropertyID=@propertyid And Status=0";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAmenityByStatusFalseDTO>(query, parameters);
                return values!.ToList();
            }
        }

        public async Task<List<ResultAmenityByStatusTrueDTO>> ResultAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityID,Title From PropertyAmenity Inner join Amenity On Amenity.AmenityId=PropertyAmenity.AmenityID Where PropertyID=@propertyid And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAmenityByStatusTrueDTO>(query, parameters);
                return values!.ToList();
            }
        }
    }
}
