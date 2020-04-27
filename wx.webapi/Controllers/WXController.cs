using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WX.Applications.Applications;

namespace wx.webapi.Controllers
{
    public class WXController : BTAPIController
    {
        /// <summary>
        ///接口调用
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        [HttpGet]
        public string webApiVerFLY(string signature, string timestamp, string nonce, string echostr) 
        {
            return echostr;
        }

        /// <summary>
        /// 获取微信测试换数据
        /// </summary>
        [HttpGet]
        public void GetAccnuber_Token() 
        {
            Applictation.GetAccess_Token();
        }

        /// <summary>
        /// 网页授权 获取 Code
        /// </summary>
        [HttpGet]
        public void GetShouQuanCode() 
        {
            var code = Applictation.GetShouQuanCode();
        }

        [HttpGet]
        public void GetMenu() 
        {
            Applictation.GetMenu();
        }

        /// <summary>
        /// 获取递归
        /// </summary>
        [HttpGet]
        public void GetDG() 
        {
            Applictation.GetDG();
        }
    }
}