using Dapper;
using RealEstateDapperApi.Dtos.CategoryDTO;
using RealEstateDapperApi.Dtos.MessageDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "SELECT TOP(3) MessageID, Name, Subject, Detail, SenderDate, IsRead,UserImageUrl FROM Message Inner join AppUser on Message.Sender=AppUser.UserID WHERE Receiver =@receiverid ORDER BY MessageID DESC;";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values!.ToList();
            }
        }
    }
}
