using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using EBCardsMVC.Models.Domain;
using EBCardsMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EBCardsMVC.Controllers
{
    [Authorize]
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var userid = User.Identity.GetUserId();
            var personas = db.Personas.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                personas = personas.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString)).ToList();
            }

            personas = personas.OrderBy(p => p.LastName).ToList();

            //for pages
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(personas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            Persona persona = new Persona();
            if (id == null)
            {
                var userid = User.Identity.GetUserId();

                persona = db.Personas.Where(x => x.User.Id == userid).FirstOrDefault();

                if (persona == null) return RedirectToAction("Create", "Personas");
            }
            else
            {
                //Check authorization here
                persona = db.Personas.Find(id);
                if (persona == null) return HttpNotFound();
                if (persona.User.Id != User.Identity.GetUserId()) return RedirectToAction("Create", "Personas");

            }
            
            return View(persona);
        }

        // GET: Personas/AddInfo/5
        public ActionResult AddInfo(int? id)
        {
            Persona persona = new Persona();
            persona = db.Personas.Find(id);
            if (persona == null) return HttpNotFound();

            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,BirthDate,Picture,WebSite,Email,Phone")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.Created = DateTime.Now;
                persona.Changed = DateTime.Now;
                var userid = User.Identity.GetUserId();
                persona.User = db.Users.Where(x => x.Id == userid).FirstOrDefault();
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        //   public ActionResult Edit([Bind(Include = "FirstName,LastName,BirthDate,Picture,WebSite,Email,Phone")] Persona persona)
        {
            /* if (ModelState.IsValid)
             {
                 db.Entry(persona).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(persona);*/

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personaToUpdate = db.Personas.Find(id);
            if (TryUpdateModel(personaToUpdate, "",
               new string[] { "FirstName", "LastName", "BirthDate", "Picture", "WebSite", "Email", "Phone" }))
            {
                try
                {
                    personaToUpdate.Changed = DateTime.Now;
                    db.Entry(personaToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details", "Personas");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(personaToUpdate);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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