using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvc_5;

namespace AspNetMvc_5.Controllers
{
    public class BILLSController : Controller
    {
        private Andrew2Context db = new Andrew2Context();

        // GET: BILLS
        public ActionResult Index()
        {
            var bILLS = db.BILLS.Include(b => b.CONTRAGENTS).Include(b => b.PERIODS).Include(b => b.TYPESOFDOC);
            return View(bILLS.ToList());
        }

        // GET: BILLS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLS bILLS = db.BILLS.Find(id);
            if (bILLS == null)
            {
                return HttpNotFound();
            }
            return View(bILLS);
        }

        // GET: BILLS/Create
        public ActionResult Create()
        {
            ViewBag.CONTRAGENT_ID = new SelectList(db.CONTRAGENTS, "ID", "NAME");
            ViewBag.PERIOD_ID = new SelectList(db.PERIODS, "ID", "SETTLEMENTPERIOD");
            ViewBag.TYPES_ID = new SelectList(db.TYPESOFDOC, "ID", "TYPEOFDOC");
            return View();
        }

        // POST: BILLS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUMERO,FILENAME,DESCRIPTION,DATE_DOC,DATE_PAY,DATE_ADD,AMOUNT,CONTRAGENT_ID,PERIOD_ID,TYPES_ID")] BILLS bILLS)
        {
            if (ModelState.IsValid)
            {
                db.BILLS.Add(bILLS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CONTRAGENT_ID = new SelectList(db.CONTRAGENTS, "ID", "NAME", bILLS.CONTRAGENT_ID);
            ViewBag.PERIOD_ID = new SelectList(db.PERIODS, "ID", "SETTLEMENTPERIOD", bILLS.PERIOD_ID);
            ViewBag.TYPES_ID = new SelectList(db.TYPESOFDOC, "ID", "TYPEOFDOC", bILLS.TYPES_ID);
            return View(bILLS);
        }

        // GET: BILLS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLS bILLS = db.BILLS.Find(id);
            if (bILLS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONTRAGENT_ID = new SelectList(db.CONTRAGENTS, "ID", "NAME", bILLS.CONTRAGENT_ID);
            ViewBag.PERIOD_ID = new SelectList(db.PERIODS, "ID", "SETTLEMENTPERIOD", bILLS.PERIOD_ID);
            ViewBag.TYPES_ID = new SelectList(db.TYPESOFDOC, "ID", "TYPEOFDOC", bILLS.TYPES_ID);
            return View(bILLS);
        }

        // POST: BILLS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUMERO,FILENAME,DESCRIPTION,DATE_DOC,DATE_PAY,DATE_ADD,AMOUNT,CONTRAGENT_ID,PERIOD_ID,TYPES_ID")] BILLS bILLS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bILLS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CONTRAGENT_ID = new SelectList(db.CONTRAGENTS, "ID", "NAME", bILLS.CONTRAGENT_ID);
            ViewBag.PERIOD_ID = new SelectList(db.PERIODS, "ID", "SETTLEMENTPERIOD", bILLS.PERIOD_ID);
            ViewBag.TYPES_ID = new SelectList(db.TYPESOFDOC, "ID", "TYPEOFDOC", bILLS.TYPES_ID);
            return View(bILLS);
        }

        // GET: BILLS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLS bILLS = db.BILLS.Find(id);
            if (bILLS == null)
            {
                return HttpNotFound();
            }
            return View(bILLS);
        }

        // POST: BILLS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BILLS bILLS = db.BILLS.Find(id);
            db.BILLS.Remove(bILLS);
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
