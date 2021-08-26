
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using FirstBank.Models;
using FirstBank.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            List<BankAccount> model = _db.BankAccounts.ToList();
            return View(model);
        }
    }
}