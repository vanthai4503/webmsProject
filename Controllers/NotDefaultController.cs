using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_music.Component;

namespace webnc_api.Controllers
{
    public class NotDefaultController : Controller
    {
        [ActivePage]
        // GET: NotDefault
        public ActionResult IndexDefault()
        {
            return View();
        }
    }
}