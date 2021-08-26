using System.Collections.Generic;
using FirstBank.Models;

namespace FirstBank.ViewModels
{
    public class BankerIndexData
    {
        public IEnumerable<Banker> Bankers { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}
