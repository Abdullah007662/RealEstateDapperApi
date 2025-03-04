namespace RealEstateDapperApi.Dtos.PopulerLocationDTO
{
    public class GetByIDPopulerLocationDTO
    {
        public int LocationID { get; set; }
        public string? CityName { get; set; }
        public string? ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}
