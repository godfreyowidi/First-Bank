/*
using System;
using Microsoft.AspNetCore.Mvc;

namespace FirstBank.Controllers
{
  public class MembersController : Controller
  {
    // GET: Student
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
                                    || s.FirstMidName.Contains(searchString));
        }
        switch (sortOrder)
        {
            case "name_desc":
                members = members.OrderByDescending(s => s.LastName);
                break;
            case "Date":
                members = members.OrderBy(s => s.EnrollmentDate);
                break;
            case "date_desc":
                members = members.OrderByDescending(s => s.EnrollmentDate);
                break;
            default:  // Name ascending 
                members = members.OrderBy(s => s.LastName);
                break;
        }

        int pageSize = 3;
        int pageNumber = (page ?? 1);
        return View(members.ToPagedList(pageNumber, pageSize));
    }


  }
}
*/