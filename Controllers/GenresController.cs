using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_music.Component;
using webnc_api.Models;

namespace webnc_api.Controllers
{
    [ActivePage]
    public class GenresController : Controller
    {
        // GET: Genres
        Models.web_nc_musicEntities1 db = new Models.web_nc_musicEntities1();
        public ActionResult IndexGenres()
        {
            if (Request.Cookies["email"] != null)
            {
                var theloaiSong = db.Baihats.GroupBy(b => b.Theloai).Select(g => g.FirstOrDefault());
                ViewBag.theloaiSong = theloaiSong.ToList();
                return View();
            }
            else
            {
                // Hiển thị hộp thoại thông báo yêu cầu đăng nhập
                TempData["ThongBao"] = "Vui lòng đăng nhập để truy cập trang này.";
                return RedirectToAction("LoginwithGG", "Home");
            }
            //var theloaiSong = db.Baihats.GroupBy(b => b.Theloai).Select(g => g.FirstOrDefault());
            //ViewBag.theloaiSong = theloaiSong.ToList();
            //return View();
        } 

    }
    }
