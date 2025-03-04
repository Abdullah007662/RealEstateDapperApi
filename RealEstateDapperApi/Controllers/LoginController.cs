using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.LoginDTO;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Tools;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDTO createLoginDTO)
        {
            string query = "SELECT * FROM AppUser WHERE UserName = @userName AND Password = @password";
            string query2 = "SELECT UserID FROM AppUser WHERE UserName = @userName AND Password = @password";

            var parameters = new DynamicParameters();
            parameters.Add("@userName", createLoginDTO.UserName);
            parameters.Add("@password", createLoginDTO.Password);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDTO>(query, parameters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIdDTO>(query2, parameters);

                if (values != null && values2 != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
                    {
                        UserName = values.UserName,
                        Id = values2.UserId
                    };
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Kullanıcı adı veya şifre hatalı!");
                }
            }
        }
    }
}
