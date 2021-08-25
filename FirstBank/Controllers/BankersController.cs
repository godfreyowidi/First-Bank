using System.Linq;
using System.Net;
using System.Web.Mvc;
using FirstBank.Models;
using FirstBank.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstBank.Controllers
{
  public class BankersController : Controller
  {
    private readonly FirstBankContext _db;

    public BankersController(UserManager<ApplicationUser> userManager, FirstBankContext db)
    {
      _db = db;
    }
    
    // GET: Banker
    public ActionResult Index(int? id, int? AccountId)
    {
        var viewModel = new BankerIndexData();

        viewModel.Bankers = _db.Bankers
            .Include(i => i.Accounts.Select(c => c.Branch))
            .OrderBy(i => i.LastName);

        if (id != null)
        {
            ViewBag.BankerId = id.Value;
            viewModel.Accounts = viewModel.Bankers.Where(
                i => i.Id == id.Value).Single().Accounts;
        }

        if (AccountId != null)
        {
            ViewBag.AccountId = AccountId.Value;
            var selectedAccount = viewModel.Accounts.Where(x => x.AccountId == AccountId).Single();
            _db.Entry(selectedAccount).Collection(x => x.AddAccounts).Load();
            foreach (AddAccount addAccount in selectedAccount.AddAccounts)
            {
                _db.Entry(addAccount).Reference(x => x.Member).Load();
            }

            viewModel.AddAccounts = selectedAccount.AddAccounts;
        }

        return View(viewModel);
    }

    // GET: Member/Details/{id}
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Banker banker = _db.Bankers.Find(id);
        if (banker == null)
        {
            return HttpNotFound();
        }
        return View(banker);
    }
  }
}