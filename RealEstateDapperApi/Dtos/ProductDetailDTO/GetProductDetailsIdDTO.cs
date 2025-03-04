namespace RealEstateDapperApi.Dtos.ProductDetailDTO
{
    public class GetProductDetailsIdDTO
    {
        public int ProductDetailsID { get; set; }
        public int BedRoomCount { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public string? BuildYear { get; set; }
        public string? ProductSize { get; set; }
        public decimal Price { get; set; }
        public string? Location { get; set; }
        public string? VideoUrl { get; set; }
        public int ProductID { get; set; }
        public DateTime Adverstisement { get; set; }
    }
}
