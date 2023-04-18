using API.Models;
using API.Repositories;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepository _walletRepository;
        public WalletController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<WalletModel>>> ListarCarteiras(int id)
        {
            List<WalletModel> wallets = await _walletRepository.AllWallets(id);
            return Ok(wallets);
        }

        [HttpPost]
        public async Task<ActionResult<WalletModel>> CadastrarCarteira([FromBody] WalletModel walletModel)
        {
            WalletModel search = await _walletRepository.FindBank(walletModel.Banco, walletModel.UserId);

            WalletModel wallet = null;
            if (search == null)
            {

                wallet = await _walletRepository.AddWallet(walletModel);
                return Ok(wallet);
            }
            else
            {
                return BadRequest("Banco já cadastrado no banco de dados");
            }
        }
    }
}
