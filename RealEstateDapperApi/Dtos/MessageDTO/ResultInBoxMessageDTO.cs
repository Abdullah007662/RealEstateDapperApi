namespace RealEstateDapperApi.Dtos.MessageDTO
{
    public class ResultInBoxMessageDTO
    {
        public int MessageID { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Detail { get; set; }
        public DateTime SenderDate { get; set; }
        public bool IsRead { get; set; }
        public string? UserImageUrl { get; set; }
    }
}
