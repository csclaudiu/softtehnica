using Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    [Authorize(Roles = "Management")]
    public class StatisticsController : BaseController
    {
        
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incasari()
        {
            var model = new incasariVM();

            model.totals = Repository.v_OrderTotals
                .OrderByDescending(o=>o.Total)
                .ToList();

            return View(model);
        }

        [Route("location/activity/{locationid?}")]
        public ActionResult ClientLocationActivity(int? locationid)
        {
            if (locationid == null)
                return RedirectToAction("Incasari");

            var model = new clientLocationActivityVM();

            model.locationActivity = Repository.v_ClientLocationActivity
                .Where(cl => cl.locationid == locationid)
                .OrderByDescending(o=>o.no_visits)
                .ToList();

            ViewBag.location = Repository.locations.FirstOrDefault(l => l.id == locationid);

            return View(model);
        }

        [Route("clients/best")]
        public ActionResult ClientActivity()
        {

            var model = new clientsActivityVM();

            model.globalActivity = Repository.v_ClientGlobalActivity
                .OrderByDescending(o => o.no_visits)
                .ToList();

            return View(model);
        }
    }
}