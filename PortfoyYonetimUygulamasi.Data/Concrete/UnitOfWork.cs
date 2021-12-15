using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Contexts;

namespace PortfoyYonetimUygulamasi.Data.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly PortfoyYonetimUygulamasiContext _context;
        private CoinRepository _conCoinRepository;
        private PortfolioRepository _portfolioRepository;
        private TransactionRepository _transactionRepository;
        private TransactionTypeRepository _transactionTypeRepository;
        private UserRepository _userRepository;
        private WalletRepository _walletRepository;

        public UnitOfWork(PortfoyYonetimUygulamasiContext context)
        {
            _context = context;
        }

    
        public ICoinRepository Coins => _conCoinRepository ?? new CoinRepository(_context);
        public IPortfolioRepository Portfolios => _portfolioRepository ?? new PortfolioRepository(_context);
        public ITransactionTypeRepository TransactionTypes => _transactionTypeRepository ?? new TransactionTypeRepository(_context);
        public ITransactionRepository Transactions => _transactionRepository ?? new TransactionRepository(_context);
        public IUserRepository Users => _userRepository ?? new UserRepository(_context);
        public IWalletRepository Wallets => _walletRepository ?? new WalletRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

    }
}
