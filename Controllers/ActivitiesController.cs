using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ZenithSocietyLib.Models;

namespace ZenithSociety.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activities
        public ActionResult Index()
        {
            return View(db.Activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityId,ActivityDescription,CreationDate")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                activities.CreationDate = DateTime.Now;
                db.Activities.Add(activities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activities);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityId,ActivityDescription,CreationDate")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                activities.CreationDate = DateTime.Now;
                db.Entry(activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activities);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activities activities = db.Activities.Find(id);
            db.Activities.Remove(activities);
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
