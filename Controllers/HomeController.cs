using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using web_music.Component;
using webnc_api.Models;

namespace webnc_api.Controllers
{
    [ActivePage]
    public class HomeController : Controller

    {
        //test
        public string LinkWeb = "https://localhost:44366/";
        
        public Taikhoan obj;
        public string GGtoken;
        public object GoogleIdentityHelper { get; private set; }
        public AuthResponse access;
        Models.web_nc_musicEntities1 db = new web_nc_musicEntities1();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult IndexHome()
        {

            var hotSong = db.Baihats
                 .Where(b => b.Trangthaibaihat == "đã phát hành")
                 .Take(6)
                 .OrderByDescending(s => s.IDSong)
                 .ToList();

            // Create a copy of the filtered hotSong list
            List<Models.Baihat> hotBaihat = new List<Models.Baihat>(hotSong);
            ViewBag.hotSong = hotSong;
            ViewBag.hotBaihat = hotBaihat;
           
            string email = null;
            Ifinity_Loop:
            if (Request.Cookies["email"] != null)
            {
                email = Request.Cookies["email"].Value;
                if (email == "tth36green@gmail.com" || email == "vanthai4503@gmail.com")
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    return RedirectToAction("IndexSong", "SongAdmin", new {Area="Admin"});
                }
                else 
                {
                    //FormsAuthentication.SetAuthCookie(email, true);
                    
                    return View();
                }
            }

            if (Request.QueryString["code"] != null)
            {
                GoogleCallback(Request.QueryString["code"].ToString());
                goto Ifinity_Loop;
                //return View();
            }
            // Người dùng chưa đăng nhập
            

            
            return View();
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
            return RedirectToAction("IndexHome");
        }
        public void LoginwithGG()
        {

            string scopes = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
            string url = string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri={1}&scope={2}&response_type=code", Idclient, LinkWeb, scopes);
            //string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=email&include_granted_scopes=true&redirect_uri=" + LinkWeb + "&response_type=code&client_id=" + Idclient + "";
            Response.Redirect(url);
        }
       
        string clientid = "";
        
        public void GoogleCallback(string code)
        {
            access = AuthResponse.Exchange(code, Idclient, clientsecret, LinkWeb);
            var url2 = $"https://www.googleapis.com/oauth2/v3/userinfo?access_token={access.Access_token}";
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; …) Gecko/20100101 Firefox/55.0");
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString(url2);
            obj = JsonConvert.DeserializeObject<Taikhoan>(json);
            //FormsAuthentication.SetAuthCookie();
            // Tạo và thiết lập giá trị cho các cookies
            HttpCookie cookie1 = new HttpCookie("Ten", obj.name);
            HttpCookie cookie2 = new HttpCookie("Anh", obj.picture);
            HttpCookie cookie3 = new HttpCookie("email", obj.email);

            // Không đặt hạn sử dụng cho tất cả các cookies, làm cho chúng vĩnh viễn
            cookie1.Expires = DateTime.MaxValue;
            cookie2.Expires = DateTime.MaxValue;
            cookie3.Expires = DateTime.MaxValue;

            // Hoặc không đặt hạn sử dụng cũng làm cho cookies vĩnh viễn
            // cookie1.Expires = DateTime.Now.AddYears(100);

            // Thêm cookies vào Response để chúng được gửi đến máy khách
            Response.Cookies.Add(cookie1);
            Response.Cookies.Add(cookie2);
            Response.Cookies.Add(cookie3);
        }
    }
}
