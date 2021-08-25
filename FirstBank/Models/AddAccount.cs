
namespace FirstBank.Models
{
  public class AddAccount
  {
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public virtual Member Member { get; set; }
  }
}