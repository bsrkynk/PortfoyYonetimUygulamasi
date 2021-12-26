using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Dtos;

namespace PortfoyYonetimUygulamasi.Host.Abstract
{
    public interface ITransactionService
    {
        Task ManageTransaction(CreateTransactionDto addCoinDto, int instancePortfolioId);
        Task AddTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId);

    }
}
