using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DBContext _dbContext;

        public WalletRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<WalletModel> AddWallet(WalletModel wallet)
        {
            await _dbContext.Wallets.AddAsync(wallet);
            await _dbContext.SaveChangesAsync();
            return wallet;
        }

        public async Task<List<WalletModel>> AllWallets(int id)
        {
            return await _dbContext.Wallets.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<WalletModel> FindBank(string banco, int userId)
        {
            return await _dbContext.Wallets.FirstOrDefaultAsync(x => x.Banco == banco && x.UserId == userId);
        }

        /*public async Task<List<WalletModel>> GetAllWallets()
        {
            return await _dbContext.Wallets.ToListAsync();
        }*/

    }
}
