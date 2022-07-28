using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SpareParts.Models;

namespace SpareParts.Controllers
{
  public class PartsController : Controller
  {
    private readonly SparePartsContext _db;

    public PartsController(SparePartsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Part> model = _db.Parts.Include(part => part.Vehicle).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.VehicleId = new SelectList(_db.Vehicles, "VehicleId", "Model");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Part part)
    {
      _db.Parts.Add(part);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Part thisPart = _db.Parts.FirstOrDefault(part => part.PartId == id);
      return View(thisPart);
    }

    public ActionResult Edit(int id)
    {
      var thisPart = _db.Parts.FirstOrDefault(part => part.PartId == id);
      ViewBag.VehicleId = new SelectList(_db.Vehicles, "VehicleId", "Model");
      return View(thisPart);
    }

    [HttpPost]
    public ActionResult Edit(Part part)
    {
      _db.Entry(part).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPart = _db.Parts.FirstOrDefault(part => part.PartId == id);
      return View(thisPart);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPart = _db.Parts.FirstOrDefault(part => part.PartId == id);
      _db.Parts.Remove(thisPart);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}