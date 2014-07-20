using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributedOutputCacheExplorations.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        [OutputCache(Duration = 3600, VaryByCustom = "User")]
        public ActionResult Index()
        {
            // NOTE you can only access this action when the session cookie is created. 
            // To do this, you can access /User, that forces a value into the session, creating the cookie.
            var currentTime = DateTime.UtcNow;
            return View(currentTime);
        }
    }
}
