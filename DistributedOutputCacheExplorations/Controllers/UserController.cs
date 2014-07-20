using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributedOutputCacheExplorations.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            // force session cookie creation so that the Vary by current User works
            Session["dummy"] = "value";

            return RedirectToAction("Index", "Dashboard");
        }

    }
}
