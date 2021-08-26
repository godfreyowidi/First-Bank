
using System;
using System.Data;
using System.Linq;
using System.Net;
//using System.Web.Mvc;
//using PagedList;
using FirstBank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace FirstBank.Controllers
{
  public class MembersController : Controller
  {
    private readonly FirstBankContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public MembersController(UserManager<ApplicationUser> userManager, FirstBankContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Details(int id)
    {
      return View();
    }
  }
}