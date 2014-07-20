using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributedOutputCacheExplorations.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [OutputCache(Duration = 120)]
        public ActionResult Index()
        {
            var currentTime = DateTime.UtcNow;
            return View(currentTime);
        }

        public string InvalidateCache()
        {
            Response.RemoveOutputCacheItem(Url.Action("Index", "Home"));
            return "Done";
        }

    }
}
