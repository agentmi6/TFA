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
    public class CharactersController : Controller
    {
        SWDatabase db = new SWDatabase();
        IRepository<Character> crepo = new CharacterRepository();

        // GET: Characters
        public ActionResult Index()
        {
            return View(crepo.GetAll());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.SideID = new SelectList(db.Sides, "ID", "TheForce");
            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        public ActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                crepo.Create(character);
                return RedirectToAction("Index");
            }
            ViewBag.SideID = new SelectList(db.Sides, "ID", "TheForce", character.SideID);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.SideID = new SelectList(db.Sides, "ID", "TheForce", character.SideID);
            return View(character);
        }

        // POST: Characters/Edit/5
        [HttpPost]
        public ActionResult Edit(Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SideID = new SelectList(db.Sides, "ID", "TheForce", character.SideID);
            return View();
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost]
        public ActionResult Delete(Character character)
        {
            crepo.Delete(character.ID);
            return RedirectToAction("Index");
        }
    }
}
