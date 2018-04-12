using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using maerskline.Models;

namespace maerskline.Controllers
{
    [Authorize]
    public class ShippmentsController : Controller
    {
        private maerskDB db = new maerskDB();

        // GET: Shippments
        public ActionResult Index()
        {
            var shippments = db.Shippments.Include(s => s.Cargo).Include(s => s.Warehouse).Include(s => s.Warehouse1);
            return View(shippments.ToList());
        }

        // GET: Shippments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippment shippment = db.Shippments.Find(id);
            if (shippment == null)
            {
                return HttpNotFound();
            }
            return View(shippment);
        }

        // GET: Shippments/Create
        public ActionResult Create()
        {
            ViewBag.cargoID = new SelectList(db.Cargoes, "cargoID", "cargoID");
            ViewBag.source = new SelectList(db.Warehouses, "warehouseID", "warehouseName");
            ViewBag.destination = new SelectList(db.Warehouses, "warehouseID", "warehouseName");
            return View();
        }

        // POST: Shippments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shippmentID,source,destination,departTime,arrivalTime,cargoID")] Shippment shippment)
        {
            if (ModelState.IsValid)
            {
                db.Shippments.Add(shippment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargoID = new SelectList(db.Cargoes, "cargoID", "cargoID", shippment.cargoID);
            ViewBag.source = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.source);
            ViewBag.destination = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.destination);
            return View(shippment);
        }

        // GET: Shippments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippment shippment = db.Shippments.Find(id);
            if (shippment == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargoID = new SelectList(db.Cargoes, "cargoID", "cargoID", shippment.cargoID);
            ViewBag.source = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.source);
            ViewBag.destination = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.destination);
            return View(shippment);
        }

        // POST: Shippments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shippmentID,source,destination,departTime,arrivalTime,cargoID")] Shippment shippment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargoID = new SelectList(db.Cargoes, "cargoID", "cargoID", shippment.cargoID);
            ViewBag.source = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.source);
            ViewBag.destination = new SelectList(db.Warehouses, "warehouseID", "warehouseName", shippment.destination);
            return View(shippment);
        }

        // GET: Shippments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shippment shippment = db.Shippments.Find(id);
            if (shippment == null)
            {
                return HttpNotFound();
            }
            return View(shippment);
        }

        // POST: Shippments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shippment shippment = db.Shippments.Find(id);
            db.Shippments.Remove(shippment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
