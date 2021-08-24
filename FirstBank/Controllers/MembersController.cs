using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using FirstBank.Models;
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

    // GET: Member
    public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
    {
        ViewBag.CurrentSort = sortOrder;
        ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

        if (searchString != null)
        {
            page = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewBag.CurrentFilter = searchString;

        var members = from s in _db.Members
                        select s;
        if (!String.IsNullOrEmpty(searchString))
        {
            members = members.Where(s => s.LastName.Contains(searchString)
                                    || s.FirstName.Contains(searchString));
        }
        switch (sortOrder)
        {
            case "name_desc":
                members = members.OrderByDescending(s => s.LastName);
                break;
            case "Date":
                members = members.OrderBy(s => s.AddAccountDate);
                break;
            case "date_desc":
                members = members.OrderByDescending(s => s.AddAccountDate);
                break;
            default: 
                members = members.OrderBy(s => s.LastName);
                break;
        }

        int pageSize = 3;
        int pageNumber = (page ?? 1);
        return View(members.ToPagedList(pageNumber, pageSize));
    }
    
    // GET: Memmber/Details/{id}
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Member member = _db.Members.Find(id);
        if (member == null)
        {
            return HttpNotFound();
        }
        return View(member);
    }

    // GET: Member/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Member/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "LastName, FirstName, AddAccountDate")]Member member)
    {
        try
        {
          if (ModelState.IsValid)
          {
              _db.Members.Add(member);
              _db.SaveChanges();
              return RedirectToAction("Index");
          }
        }
        catch (RetryLimitExceededException /* dex */)
        {
            
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists check with your nearest branch.");
        }
        return View(member);
    }

  }
}