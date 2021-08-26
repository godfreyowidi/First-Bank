using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstBank.Models;
using System.Linq;

namespace FirstBank.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FirstBankContext _db;

        public TransactionsController(FirstBankContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}