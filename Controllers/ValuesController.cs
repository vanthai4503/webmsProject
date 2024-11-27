using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webnc_api.Models;

namespace webnc_api.Controllers
{
    public class ValuesController : ApiController
    {
        Models.web_nc_musicEntities1 db = new web_nc_musicEntities1();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/playlists/layraplaylisttheoid")]
        public IEnumerable<Models.Baihat> LayPlaylisttheoid(string id)
        {
            var lst = db.Baihats.AsEnumerable();

            if (!string.IsNullOrEmpty(id))
            {
                lst = lst.Where(baihat => baihat.Chitietlists.Any(chitiet => chitiet.Danhsachphat.IDlist == id));
            }
            var result = lst.Select(baihat => new Baihat
            {
                IDSong = baihat.IDSong,
                Tenbai = baihat.Tenbai,
                Casi = baihat.Casi,
                Thoiluong = baihat.Thoiluong,
                Theloai = baihat.Theloai,
                Linkbaihat = baihat.Linkbaihat,
                Img = baihat.Img
            });
            return result;
        }
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
