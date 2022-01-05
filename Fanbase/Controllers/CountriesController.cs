using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Fanbase.Models;

namespace Fanbase.Controllers
{
  public class CountriesController : Controller
  {
    private readonly FanbaseContext _db;

    public CountriesController(FanbaseContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Countries.ToList());
    }

    public ActionResult Details(int id)
    {
      Country thisCountry = _db.Countries
        .Include(country => country.Actors)
        .Include(country => country.Films)
        .FirstOrDefault(country => country.CountryId == id);
      return View(thisCountry);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Country country)
    {
      _db.Countries.Add(country);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Country thisCountry = _db.Countries.FirstOrDefault(country => country.CountryId == id);
      return View(thisCountry);
    }

    [HttpPost]
    public ActionResult Edit(Country country)
    {
      _db.Entry(country).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", country.CountryId);
    }

    public ActionResult Delete(int id)
    {
      Country thisCountry = _db.Countries.FirstOrDefault(country => country.CountryId == id);
      return View(thisCountry);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Country thisCountry = _db.Countries.FirstOrDefault(country => country.CountryId == id);
      _db.Countries.Remove(thisCountry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}