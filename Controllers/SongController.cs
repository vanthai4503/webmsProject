using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webnc_api.Models;

namespace webnc_api.Controllers
{
    public class SongController : ApiController
    {
        private web_nc_musicEntities1 db = new web_nc_musicEntities1();

        // GET: api/Song
        public IQueryable<Baihat> GetBaihat()
        {
            return db.Baihats;
        }
        

        // GET: api/Song/5
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult GetBaihat(int id)
        {
            Baihat baihat = db.Baihats.Find(id);
            if (baihat == null)
            {
                return NotFound();
            }

            return Ok(baihat);
        }

        //Playlist

        public class taoplaylist
        {
            public string ten { get; set; }
            public string email { get; set; }
        }
        [HttpPost]
        [Route("api/Song/themplaylist")]
        public void themplaylist([FromBody] taoplaylist value)
        {
            taoplaylist pll = new taoplaylist();
            var json = JsonConvert.SerializeObject(value);
            pll = JsonConvert.DeserializeObject<taoplaylist>(json);
            DateTime dt = DateTime.Now;
            string chudt = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string fileName = pll.email + chudt;
            Models.Danhsachphat dsp = new Danhsachphat();
            dsp.Tendanhsach = pll.ten;
            dsp.Email = pll.email;
            dsp.IDlist = fileName;
            db.Danhsachphats.Add(dsp);
            db.SaveChanges();
        }

        //Thể loại
        [HttpGet]
        [Route("api/Song/SearchGeners")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult SearchGeners(string tenTL)
        {

            var lst = db.Baihats.Where(x => x.Theloai.ToLower().Contains(tenTL))
            .Select(x => new 
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(lst);
        }

        //Ca sĩ
        [HttpGet]
        [Route("api/Song/SearchSinger")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult SearchSinger(string tenCasi)
        {

            var lst = db.Baihats.Where(x => x.Casi.ToLower().Contains(tenCasi))
            .Select(x => new
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(lst);
        }

        //search theo tên
        [HttpGet]
        [Route("api/Song/SearchName")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult SearchName(string tukhoa)
        {

            var lst = db.Baihats.Where(x => x.Tenbai.ToLower().Contains(tukhoa))
            .Select(x => new
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(lst);
        }
        //danh sách song
        [HttpGet]
        [Route("api/Song/ListSong")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult ListSong()
        {

            var lst = db.Baihats
            .Select(x => new
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(lst);
        }
        //lay bai hat id
        [HttpGet]
        [Route("api/Song/laysongID")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult laysongID(int id)
        {

            var lst = db.Baihats.Where(x => x.IDSong ==id)
            .Select(x => new
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(lst);
        }
        //search theo tên
        [HttpGet]
        [Route("api/Song/layPlaylistId")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult layPlaylistId(string idlist)
        {
            var lst = db.Baihats.AsEnumerable();
            //tạo danh sách bài hát chuyển về dạng IEnumerable
            lst = lst.Where(s => s.Chitietlists.Any(c => c.Danhsachphat.IDlist == idlist));
            var result= lst.Select(x => new Baihat
            {
                IDSong = x.IDSong,
                Tenbai = x.Tenbai,
                Casi = x.Casi,
                Thoiluong = x.Thoiluong,
                Theloai = x.Theloai,
                Linkbaihat = x.Linkbaihat,
                Img = x.Img
            }).ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("api/playlists/layplaylisttheoemail")]
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult Layplaylisttheoemail(string id)
        {
            List<dsphatcoanh> dsphat = new List<dsphatcoanh>();
            var lst = db.Danhsachphats.AsEnumerable();
            //chuyển dữ liệu sang isA

            if (!string.IsNullOrEmpty(id))
            {
                lst = lst.Where(chitiet => chitiet.Email == id);
            }
            var result = lst.Select(baihat => new Danhsachphat
            {
                IDlist = baihat.IDlist,
                Email = baihat.Email,
                Tendanhsach = baihat.Tendanhsach
            });
            foreach (var item in result)
            {
                dsphatcoanh ds = new dsphatcoanh();
                ds.IDlist = item.IDlist;
                ds.Email = item.Email;
                ds.Tendanhsach = item.Tendanhsach;
                var lst2 = db.Baihats.AsEnumerable();

                if (!string.IsNullOrEmpty(item.IDlist))
                {
                    lst2 = lst2.Where(baihat => baihat.Chitietlists.Any(chitiet => chitiet.Danhsachphat.IDlist == item.IDlist));
                    var result2 = lst2.Select(baihat => new Baihat
                    {
                        IDSong = baihat.IDSong,
                        Tenbai = baihat.Tenbai,
                        Casi = baihat.Casi,
                        Thoiluong = baihat.Thoiluong,
                        Theloai = baihat.Theloai,
                        Linkbaihat = baihat.Linkbaihat,
                        Img = baihat.Img
                    });
                    if (lst2.Count() > 0)
                    {
                        ds.linkanh = result2.First().Img;
                    }
                    dsphat.Add(ds);
                }

            }
            return Ok(dsphat);
        }
        // PUT: api/Song/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaihat(int id, Baihat baihat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baihat.IDSong)
            {
                return BadRequest();
            }

            db.Entry(baihat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaihatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Song
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult PostBaihat(Baihat baihat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Baihats.Add(baihat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baihat.IDSong }, baihat);
        }

        // DELETE: api/Song/5
        [ResponseType(typeof(Baihat))]
        public IHttpActionResult DeleteBaihat(int id)
        {
            Baihat baihat = db.Baihats.Find(id);
            if (baihat == null)
            {
                return NotFound();
            }

            db.Baihats.Remove(baihat);
            db.SaveChanges();

            return Ok(baihat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaihatExists(int id)
        {
            return db.Baihats.Count(e => e.IDSong == id) > 0;
        }
    }
}