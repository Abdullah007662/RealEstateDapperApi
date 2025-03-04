using RealEstateDapperApi.Dtos.ContactDTO;

namespace RealEstateDapperApi.Repositories.ContactRepositories
{
    public interface IContactRespository
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task<List<Last4ContactResultDTO>> GetLast4ContactAsync();
        Task CreateContact(CreateContactDTO createContactDTO);
        Task DeleteContact(int id);
        Task UpdateContact(UpdateContactDTO updateContactDTO);
        Task<GetByIDContactDTO> GetByIDContact(int id);
    }
}
