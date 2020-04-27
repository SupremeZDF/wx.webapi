using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Model
{
    public class F4402Select
    {
        [PFPayment("head")]
        public string transCode { get; set; }

        [PFPayment("head")]
        public string signFlag { get; set; }

        [PFPayment("head")]
        public string packetID { get; set; }

        [PFPayment("head")]
        public string masterID { get; set; }

        [PFPayment("head")]
        public string timeStamp { get; set; }

        [PFPayment("body")]
        public string GetTimeString { get; set; }

        [PFPayment("body",XMLBoadName = "acctList")]
        public List<ListacctNo> lists { get; set;  }

    }

    public class ListacctNo 
    {
        [PFPayment("body", XMLBoadName = "list")]
        public string acctNo { get; set; }
    }
}
