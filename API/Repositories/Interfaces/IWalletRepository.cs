using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        //Task<List<WalletModel>> GetAllWallets();
        Task<WalletModel> AddWallet(WalletModel wallet);
        Task<List<WalletModel>> AllWallets(int id);
        Task<WalletModel> FindBank(string banco, int userid);
    }
}
