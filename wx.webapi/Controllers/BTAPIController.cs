using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WX.Applications.Applications;
using WX.Model;

namespace wx.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BTAPIController : ControllerBase
    {
        /// <summary>
        /// 获取XML文档
        /// </summary>
        [HttpGet]
        public void GetXmlString()
        {
            var obj = new F4402Select()
            {
                transCode = "4402",
                signFlag = "1",
                packetID = "1234567890",
                masterID = "1122334455",
                timeStamp = "2004-07-28 16:14:25",
                lists = new List<ListacctNo>()
            {
            new ListacctNo()
            {
            acctNo="12345678900000"
            }
            }
            };
            Applictation.GetXMLString(obj);
        }
    }
}
