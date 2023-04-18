using API.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /*[HttpGet]
        public async Task<ActionResult<List<UserModel>>> ListarUsuarios()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }*/

        [HttpPost]
        public async Task<ActionResult<UserModel>> CadastrarUsuario([FromBody] UserModel userModel)
        {
            UserModel search = await _userRepository.FindCPF(userModel.CPF);

            UserModel user = null;
            if (search == null)
            {

                user = await _userRepository.AddUser(userModel);
                return Ok(user);
            } else
            {
                return BadRequest("CPF já cadastrado no banco de dados");
            }
        }
    }
}
