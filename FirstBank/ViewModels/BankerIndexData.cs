using System.Collections.Generic;
using FirstBank.Models;

namespace FirstBank.ViewModels
{
    public class BankerIndexData
    {
        public IEnumerable<Banker> Bankers { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<AddAccount> AddAccounts { get; set; }
    }
}
