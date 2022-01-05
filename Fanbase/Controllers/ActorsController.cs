using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Fanbase.Models;

namespace Fanbase.Controllers
{
  public class ActorsController : Controller
  {
    private readonly FanbaseContext _db;

    public ActorsController(FanbaseContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Actor> model = _db.Actors.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      var thisActor = _db.Actors
        .Include(actor => actor.JoinEntities)
        .ThenInclude(join => join.Film)
        .FirstOrDefault(actor => actor.ActorId == id);
      return View(thisActor);
    }

    public ActionResult Create()
    {
      ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Actor actor)
    {
      _db.Actors.Add(actor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name");
      Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      return View(thisActor);
    }

    public ActionResult AddFilm(int id)
    {
      var thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      ViewBag.FilmId = new SelectList(_db.Films, "FilmId", "Name");
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult AddFilm(Actor actor, int FilmId)
    {
      bool alreadyExists = _db.ActorFilm.Any(actorFilm => actorFilm.ActorId == actor.ActorId && actorFilm.FilmId == FilmId);
      if (FilmId != 0 && !alreadyExists)
      {
        _db.ActorFilm.Add(new ActorFilm() { ActorId = actor.ActorId, FilmId = FilmId });
      }
      _db.SaveChanges();
      if (alreadyExists)
      {
        return RedirectToAction("AddFilmError");
      }
      return RedirectToAction("Index");
    }

    public ActionResult AddFilmError()
    {
      return View();
    }

    [HttpPost]
    public ActionResult DeleteFilm(int joinId)
    {
      ActorFilm joinEntry = _db.ActorFilm.FirstOrDefault(entry => entry.ActorFilmId == joinId);
      _db.ActorFilm.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", joinEntry.ActorId);
    }

    public ActionResult Delete(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      return View(thisActor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actor => actor.ActorId == id);
      _db.Actors.Remove(thisActor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
