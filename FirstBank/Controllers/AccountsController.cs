using Microsoft.AspNetCore.Mvc;

namespace FirstBank.Controllers
{
  public class AccountsControllers : Controller
  {
    public ActionResult Register()
    {
      return View();
    }
    
  }
}