using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_music.Component;

namespace webnc_api.Controllers
{
    [ActivePage]
    public class PlaylistImgController : Controller
        // GET: PlaylistImg
    {
        Models.web_nc_musicEntities1 db = new Models.web_nc_musicEntities1();
        public ActionResult IndexPlImg()
        {
            var result = db.Danhsachphats;
            ViewBag.result = result.ToList();
            return View();
        }
    }
}