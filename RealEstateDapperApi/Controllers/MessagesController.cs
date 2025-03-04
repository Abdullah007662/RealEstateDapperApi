using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.MessageRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [HttpGet]
        public async Task< IActionResult> GetMessage(int id)
        {
            var values=await _messageRepository.GetInBoxLast3MessageListByReceiver(id);
            return Ok(values);
        }
    }
}
