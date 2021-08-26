using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstBank.Models;
using System.Linq;

namespace FirstBank.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly FirstBankContext _db;

        public BankAccountsController(FirstBankContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<BankAccount> model = _db.BankAccounts.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BankAccount bankAccount)
        {
            _db.BankAccounts.Add(bankAccount);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}