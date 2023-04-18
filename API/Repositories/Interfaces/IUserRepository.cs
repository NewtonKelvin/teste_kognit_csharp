using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Task<List<UserModel>> GetAllUsers();
        Task<UserModel> AddUser(UserModel user);

        Task<UserModel> FindCPF(string cpf);
    }
}
