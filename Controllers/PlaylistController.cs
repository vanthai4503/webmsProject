using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web_music.Component;

namespace webnc_api.Controllers
{
    [ActivePage]
    public class PlaylistController : Controller
    {
        HomeController homeController;
        // GET: Playlist
        Models.web_nc_musicEntities1 db = new Models.web_nc_musicEntities1();

        public ActionResult IndexPlaylist()
        {
            if (Request.Cookies["email"] != null)
            {
                var idPlaylist = db.Chitietlists.GroupBy(b => b.IDlist).Select(g => g.FirstOrDefault());
                ViewBag.idPlaylist = idPlaylist.ToList();
                return View();
            }
            else
            {
                // Hiển thị hộp thoại thông báo yêu cầu đăng nhập
                TempData["ThongBao"] = "Vui lòng đăng nhập để truy cập trang này.";
                return RedirectToAction("LoginwithGG", "Home");
            }
            //var idPlaylist = db.Chitietlists.GroupBy(b => b.IDlist).Select(g => g.FirstOrDefault());
            //ViewBag.idPlaylist = idPlaylist.ToList();
            //return View();

        }
    }
}