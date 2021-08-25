using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstBank.Models
{
  public class FirstBankContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Banker> Bankers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<AddAccount> AddAccounts { get; set; }

    public FirstBankContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
      optionBuilder.UseLazyLoadingProxies();
    }
  }
}