using System.Collections.Generic;
using System.Web.Mvc;
using markets_aspnet.Models;
using markets_aspnet.Queries;
using Npgsql;

namespace markets_aspnet.Controllers
{
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

        public JsonResult Exposures(string path)
        {
            var query = new ExposuresQuery();

            var exposures = query.Execute(path);

            return Json(exposures, JsonRequestBehavior.AllowGet);
        }
    }
}