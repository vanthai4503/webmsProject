﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webnc_api.Models
{
    public class Taikhoan
    {
        public string sub { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string picture { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string locale { get; set; }
    }
}