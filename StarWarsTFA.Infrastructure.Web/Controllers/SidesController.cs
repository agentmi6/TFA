using StarWarsTFA.Domain;
using StarWarsTFA.Domain.RepositoryInterfaces;
using StarWarsTFA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StarWarsTFA.Infrastructure.Web.Controllers
{
    public class SidesController : Controller
    {
        SWDatabase db = new SWDatabase();
        IRepository<Side> srepo = new SideRepository();

        // GET: Sides
        public ActionResult Index()
        {
            return View(srepo.GetAll());
        }

        // GET: Sides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Side side = db.Sides.Find(id);
            if (side == null)
            {
                return HttpNotFound();
            }
            return View(side);
        }

        // GET: Sides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sides/Create
        [HttpPost]
        public ActionResult Create(Side side)
        {
            if (ModelState.IsValid)
            {
                srepo.Create(side);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Sides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Side side = db.Sides.Find(id);
            if (side == null)
            {
                return HttpNotFound();
            }
            return View(side);
        }

        // POST: Sides/Edit/5
        [HttpPost]
        public ActionResult Edit(Side side)
        {
            if (ModelState.IsValid)
            {
                db.Entry(side).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Sides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Side side = db.Sides.Find(id);
            if (side == null)
            {
                return HttpNotFound();
            }
            return View(side);
        }

        // POST: Sides/Delete/5
        [HttpPost]
        public ActionResult Delete(Side side)
        {
            srepo.Delete(side.ID);
            return RedirectToAction("Index");
        }
    }
}
