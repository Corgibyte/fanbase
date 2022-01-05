using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Fanbase.Models;

namespace Fanbase.Controllers
{
  public class FilmsController : Controller
  {
    private readonly FanbaseContext _db;

    public FilmsController(FanbaseContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Films.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisFilm = _db.Films
        .Include(film => film.JoinEntities)
        .ThenInclude(join => join.Actor)
        .FirstOrDefault(film => film.FilmId == id);
      return View(thisFilm);
    }

    public ActionResult Create()
    {
      ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Film film)
    {
      _db.Films.Add(film);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name");
      Film thisFilm = _db.Films.FirstOrDefault(film => film.FilmId == id);
      return View(thisFilm);
    }

    [HttpPost]
    public ActionResult Edit(Film film)
    {
      _db.Entry(film).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(Film => Film.FilmId == id);
      return View(thisFilm);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(Film => Film.FilmId == id);
      _db.Films.Remove(thisFilm);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}