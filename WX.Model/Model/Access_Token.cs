using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Model.Model
{
    public class Access_Token
    {
        public string grant_type { get; set; }

        public string appid { get; set; }

        public string secret { get; set; }
    }
}
