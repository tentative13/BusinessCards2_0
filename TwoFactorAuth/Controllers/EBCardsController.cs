
using EBCardsMVC.Models;
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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EBCardsMVC.Controllers
{
    [Authorize]
    public class EBCardsController : Controller
    {
            private ApplicationDbContext db = new ApplicationDbContext();

            // GET: BusinessCards
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
                var persona = db.Personas.Where(x => x.User.Id == userid).FirstOrDefault();

                if (persona == null)return RedirectToAction("Create", "Personas");
                
                var shared_cards = db.BusinessCardsTo.Where(x => x.ShareWith.ID == persona.ID).Select(x=>x.BusinessCard.ID).ToList();
                
                var businesscards = db.BusinessCards.Where( x=>shared_cards.Contains(x.ID));//.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    businesscards = businesscards.Where(b => b.CompanyName.Contains(searchString)
                                           || b.Position.Contains(searchString));
                }

                businesscards = businesscards.OrderBy(b => b.CompanyName);

                //for pages
                int pageSize = 3;
                int pageNumber = (page ?? 1);

                var userId = User.Identity.GetUserId();

                return View(businesscards.ToPagedList(pageNumber, pageSize));


                //return View(db.BusinessCards.ToList());
            }





            // GET: BusinessCards/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BusinessCard businessCard = db.BusinessCards.Find(id);
                if (businessCard == null)
                {
                    return HttpNotFound();
                }
                return View(businessCard);
            }

            // GET: BusinessCards/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: BusinessCards/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "CompanyName,Email,Phone,Position,CompanyLogo,WebSite,BusinessDemo")] BusinessCard businessCard)
            {
                if (ModelState.IsValid)
                {
                    businessCard.Created = DateTime.Now;
                    businessCard.ChangedDate = DateTime.Now;
                    var userid = User.Identity.GetUserId();
                    businessCard.Persona = db.Personas.Where(x => x.User.Id == userid).FirstOrDefault();
                    db.BusinessCards.Add(businessCard);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Personas");
                }

                return View(businessCard);
            }

            // GET: BusinessCards/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BusinessCard businessCard = db.BusinessCards.Find(id);
                if (businessCard == null)
                {
                    return HttpNotFound();
                }
                return View(businessCard);
            }

            // POST: BusinessCards/Edit/5
            [HttpPost, ActionName("Edit")]
            [ValidateAntiForgeryToken]
            public ActionResult EditPost(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var businesscardToUpdate = db.BusinessCards.Find(id);
                if (TryUpdateModel(businesscardToUpdate, "",
                   new string[] { "CompanyName", "Email", "Phone", "Position", "CompanyLogo", "WebSite", "BusinessDemo" }))
                {
                    try
                    {
                        businesscardToUpdate.ChangedDate = DateTime.Now;
                        db.Entry(businesscardToUpdate).State = EntityState.Modified;
                        db.SaveChanges();

                        return RedirectToAction("Details", "Personas");
                    }
                    catch (DataException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                return RedirectToAction("Details", "Personas");
            }



            // GET: BusinessCards/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BusinessCard businessCard = db.BusinessCards.Find(id);
                if (businessCard == null)
                {
                    return HttpNotFound();
                }
                return View(businessCard);
            }

            // POST: BusinessCards/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                BusinessCard businessCard = db.BusinessCards.Find(id);
                db.BusinessCards.Remove(businessCard);
                db.SaveChanges();
                return RedirectToAction("Details", "Personas");
            }



            // GET: BusinessCards/Delete/5
            public ActionResult Share(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BusinessCard businessCard = db.BusinessCards.Find(id);
                if (businessCard == null)
                {
                    return HttpNotFound();
                }
                return View(businessCard);
            }

            // POST: BusinessCards/Delete/5
            [HttpPost, ActionName("Share")]
            [ValidateAntiForgeryToken]
            public ActionResult ShareConfirmed(int id)
            {
                BusinessCard businessCard = db.BusinessCards.Find(id);
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