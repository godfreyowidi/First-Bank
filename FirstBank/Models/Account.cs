using System.Collections.Generic;

namespace FirstBank.Models
{
  public class Account
  {
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    public int AccountNumber { get; set; }
    public int AccountBalance { get; set; }

    public virtual Branch Branch { get; set; }
    public virtual ICollection<AddAccount> AddAccounts { get; set; }
    public virtual ICollection<Banker> Bankers { get; set; }
  }
}