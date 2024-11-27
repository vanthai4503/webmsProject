using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnc_api.Models;
using NAudio.Wave;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;
using System.Web.Security;

namespace webnc_api.Areas.Admin.Controllers
{
    [Authorize]
    public class SongAdminController : Controller
    {
        // GET: Admin/SongAdmin
        Models.web_nc_musicEntities1 db = new Models.web_nc_musicEntities1();
        private List<SelectListItem> GetTheloaiLists()
        {
            var theloaiList = new List<SelectListItem>
            {
            new SelectListItem { Value ="K-POP",Text = "K-POP"},
            new SelectListItem { Value ="V-POP",Text = "V-POP"},
            new SelectListItem { Value ="US-UK",Text = "US-UK"},
            new SelectListItem { Value ="C-POP",Text = "C-POP"},
            };
            return theloaiList;

        }
        public ActionResult IndexSong()
        {

            //List<Baihat> lst = db.Baihats.ToList();

            //return View(lst);
            var lst = db.Baihats.ToList();

            // Filter the list to include only Baihat with Trangthaiphathanh = "chưa phát hành"
            lst = lst.Where(b => b.Trangthaibaihat == "chưa phát hành").ToList();

            // Return the filtered list to the view
            return View(lst);
        }

        public ActionResult IndexSongPublish()
        {

            //List<Baihat> lst = db.Baihats.ToList();

            //return View(lst);
            var lst = db.Baihats.ToList();

            // Filter the list to include only Baihat with Trangthaiphathanh = "chưa phát hành"
            lst = lst.Where(b => b.Trangthaibaihat == "đã phát hành").ToList();

            // Return the filtered list to the view
            return View(lst);
        }



        [HttpGet]
        public ActionResult ThemBai()
        {
            ViewBag.TheloaiList = GetTheloaiLists();
            return View();
        }

        [HttpPost]
        public ActionResult ThemBai(Baihat obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string email = null;
                    // Gán độ dài và bitrate vào đối tượng Baihat
                    var flinksong = Request.Files["flinksong"];
                    var flinkimg = Request.Files["flinkimg"];
                    var ttbh = "đã phát hành";
                    email = Request.Cookies["email"].Value;

                    var like = 0;
                    var mp3File = new Mp3FileReader(flinksong.InputStream);
                    long length = mp3File.TotalTime.Ticks;
                    long sogiay = length / 10000000;
                    long sophut = sogiay / 60;
                    long sogiaythua = sogiay % 60;
                    string dodai = sophut.ToString() + ":" + sogiaythua.ToString();
                    // Gán độ dài và bitrate vào đối tượng Baihat
                    obj.Thoiluong = dodai;
                    obj.Trangthaibaihat = ttbh;
                    obj.LuotThich = like;
                    obj.IDCasi = email;
                    if (flinksong != null && flinksong.ContentLength > 0)
                    {
                        DateTime dt = DateTime.Now;
                        string chudt = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        string fileName = obj.Tenbai + chudt + ".mp3"; //tự sinh tên file
                                                                       //string fileName = flinksong.FileName;
                        string fileName2 = fileName.Replace(":", "-");
                        string foderPath = Server.MapPath("~/Assets/audio/" + fileName2);
                        flinksong.SaveAs(foderPath);
                        obj.Linkbaihat = "/Assets/audio/" + fileName2;
                    }
                    if (flinkimg != null && flinkimg.ContentLength > 0)
                    {
                        DateTime dt = DateTime.Now;
                        string chudt = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        string fileName = chudt + ".jpg"; //tự sinh tên file
                        string fileName2 = fileName.Replace(":", "-");
                        string foderPath = Server.MapPath("~/Assets/Admin/images/uploadimg/" + fileName2);
                        flinkimg.SaveAs(foderPath);
                        obj.Img = "/Assets/Admin/images/uploadimg/" + fileName2;
                        //string fName2 = flinksong.FileName;
                        //string foderPath = Server.MapPath("~/Assets/images/uploadimg/" + fName2);
                        //flinkimg.SaveAs(foderPath);
                        //obj.Img = "/Assets/images/uploadimg/" + fName2;
                    }
                    db.Baihats.Add(obj);
                    //db.Baihats.Add(baihat);
                    db.SaveChanges();
                    
                    return RedirectToAction("IndexSong");
                }
                catch (Exception ex)
                {
                    // In thông báo ngoại lệ vào Output Window
                    Console.WriteLine(ex.Message);
                    throw; // Ném lại ngoại lệ để xem chi tiết
                }
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int Id)

        {
            Baihat obj = db.Baihats.Find(Id);
            ViewBag.TheloaiList = GetTheloaiLists();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Baihat obj)
        {
            try
            {
                var flinkimg = Request.Files["flinkimg"];
                if (flinkimg != null && flinkimg.ContentLength > 0)
                {
                    DateTime dt = DateTime.Now;
                    string chudt = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    string fileName = chudt + ".jpg"; //tự sinh tên file
                    string fileName2 = fileName.Replace(":", "-");
                    string foderPath = Server.MapPath("~/Assets/Admin/images/uploadimg/" + fileName2);
                    flinkimg.SaveAs(foderPath);
                    obj.Img = "/Assets/Admin/images/uploadimg/" + fileName2;
                }
                Baihat editobj = db.Baihats.Find(obj.IDSong);
                if (flinkimg == null && flinkimg.ContentLength == 0)
                {
                    editobj.Tenbai = obj.Tenbai;
                    editobj.Casi = obj.Casi;
                    editobj.Theloai = obj.Theloai;
                }
                else
                {
                    editobj.Tenbai = obj.Tenbai;
                    editobj.Casi = obj.Casi;
                    editobj.Theloai = obj.Theloai;
                    editobj.Img = obj.Img;
                }  
                   
                
               
               


                db.SaveChanges();

                return RedirectToAction("IndexSong");
            }
            catch
            {

            }
            return View(obj);
        }


        public ActionResult Delete(int id)
        {
            Baihat delBh = db.Baihats.Find(id);
            if (delBh != null)
            {
                db.Baihats.Remove(delBh);
                // Xóa tất cả các bản ghi trong bảng chi tiết list có khóa ngoại trùng với id của bản ghi trong bảng chính
                db.Chitietlists.RemoveRange(db.Chitietlists.Where(c => c.IDsong == id));
                db.SaveChanges();
            }
            return RedirectToAction("IndexSong");
        }

        public ActionResult Doitrangthai(int id)
        {
            Baihat delBh = db.Baihats.Find(id);
            if (delBh != null)
            {
                delBh.Trangthaibaihat = "đã phát hành";
                // Return the filtered list to the view

                db.SaveChanges();
            }
            return RedirectToAction("IndexSong");
        }
        public ActionResult xoacokki()
        {
            if (Request.Cookies["email"] != null)
            {
                HttpCookie myCookie = new HttpCookie("email");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            if (Request.Cookies["Ten"] != null)
            {
                HttpCookie myCookie = new HttpCookie("Ten");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            if (Request.Cookies["Anh"] != null)
            {
                HttpCookie myCookie = new HttpCookie("Anh");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("IndexHome", "Home", new { area = "" });
        }
    }
}