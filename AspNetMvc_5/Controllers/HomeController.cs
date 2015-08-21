namespace AspNetMvc_5.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Moved From BillsController For Public Access :
        private Andrew2Context db = new Andrew2Context();

        public ActionResult Bills()
        {
            var bILLS = db.BILLS.Include(b => b.CONTRAGENTS).Include(b => b.PERIODS).Include(b => b.TYPESOFDOC);
            return View(bILLS.ToList());
        }
    }
}