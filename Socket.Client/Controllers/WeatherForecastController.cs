using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WX.Applications;

namespace Socket.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// 启动客户端 Socket
        /// </summary>
        [HttpGet]
        public void GetName() 
        {
            SocketClient socketClient = new SocketClient(8884);
            socketClient.StartClient();
        }
    }
}
