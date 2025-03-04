using RealEstateDapperApi.Dtos.MessageDTO;

namespace RealEstateDapperApi.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id);
    }
}
