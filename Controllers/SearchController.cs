using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webnc_api.Controllers
{
    public class SearchController : Controller
    {
        Models.web_nc_musicEntities1 db = new Models.web_nc_musicEntities1();
        // GET: Search
        public ActionResult IndexSearch()

        {

            return View();
        }
    }
}