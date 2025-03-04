using Dapper;
using RealEstateDapperApi.Dtos.ContactDTO;
using RealEstateDapperApi.Dtos.EmployeeDTO;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRespository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDTO createContactDTO)
        {
            string query = "insert into Contact (Name,Subject,Email,Message,SendDate) values (@name,@subject,@email,@message,@sendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createContactDTO.Name);
            parameters.Add("@subject", createContactDTO.Subject);
            parameters.Add("@mail", createContactDTO.Email);
            parameters.Add("@message", createContactDTO.Message);
            parameters.Add("@sendDate", createContactDTO.SendDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "Delete From Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDTO> GetByIDContact(int id)
        {
            string query = "Select * From Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactDTO>(query, parameters);
                return values!;
            }
        }

        public async Task<List<Last4ContactResultDTO>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact order by ContactID desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDTO>(query);
                return values.ToList();
            }
        }

        public async Task UpdateContact(UpdateContactDTO updateContactDTO)
        {
            string query = "Update Contact Set Name=@name,Subject=@subject,Email=@email,Message=@message,SendDate=@sendDate where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateContactDTO.Name);
            parameters.Add("@subject", updateContactDTO.Subject);
            parameters.Add("@email", updateContactDTO.Email);
            parameters.Add("@message", updateContactDTO.Message);
            parameters.Add("@sendDate", updateContactDTO.SendDate);
            parameters.Add("@contactID", updateContactDTO.ContactID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
