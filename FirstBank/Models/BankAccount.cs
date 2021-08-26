using System.Collections.Generic;

namespace FirstBank.Models
{
  public class BankAccount : Person
  {
    public int BankAccountId { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip { get; set; }

    public virtual ICollection<Banker> Bankers { get; set; }
    public virtual ICollection<Member> Members { get; set; }
  }
}
