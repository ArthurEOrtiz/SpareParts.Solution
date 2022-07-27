using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SpareParts.Models;

namespace SpareParts.Controllers
{
  public class SparePartsController : Controller
  {
      private readonly SparePartsContext _db;

      public VehiclesController(SparePartsContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Vehicle> model = _db.Vehicles.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Vehicle Vehicle)
      {
        _db.Vehicles.Add(vehicle);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        Vehicle thisVehicle = _db.Vehicles.FirstOrDefault(vehicle => vehicle.VehicleId == id);
        return View(thisVehicle);
      }
      public ActionResult Edit(int id)
      {
        var thisVehicle = _db.Vehicles.FirstOrDefault(vehicle => vehicle.VehicleId == id);
        return View(thisVehicle);
      }

      [HttpPost]
      public ActionResult Edit(Vehicle vehicle)
      {
        _db.Entry(vehicle).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var thisVehicle = _db.Vehicles.FirstOrDefault(vehicle => vehicle.VehicleId == id);
        return View(thisVehicle);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisVehicle = _db.Vehicles.FirstOrDefault(vehicle => vehicle.VehicleId == id);
        _db.Vehicles.Remove(thisVehicle);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}