using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstaction
{
    public interface ITransactionService
    {
        Task<bool> ProcessAsync(Account account);
    }
}
