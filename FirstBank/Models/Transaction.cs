namespace FirstBank.Models
{
  public class Transaction
  {
    public int TransactionId { get; set; }
    public int Withdraw { get; set; }
    public int Deposit { get; set; }
    public int Transfer { get; set; }
  }
}