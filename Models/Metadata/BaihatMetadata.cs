using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace webnc_api.Models.Metadata
{
    public class BaihatMetadata
    {
        [DisplayName("Mã bài hát")]
        public int IDSong { get; set; }

        [DisplayName("Tên bài hát")]
        public string Tenbai { get; set; }

        [DisplayName("Ca sĩ")]
        public string Casi { get; set; }

        [DisplayName("Thời lượng")]
        public string Thoiluong { get; set; }

        [DisplayName("Thể loại")]
        public string Theloai { get; set; }

        [DisplayName("Link bài hát")]
        public string Linkbaihat { get; set; }

        [DisplayName("Ảnh")]
        public string Img { get; set; }
    }
}