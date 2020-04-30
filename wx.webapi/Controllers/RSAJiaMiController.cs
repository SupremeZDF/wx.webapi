using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WX.Applications;

namespace wx.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAJiaMiController : ControllerBase
    {
        
        /// <summary>
        /// GetJiaMi
        /// </summary>
        [HttpGet]
        public void GetMd5() 
        {
            RSAApplication.GetMd5Str();
        }
    }
}