using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WX.Applications.Dappers;

namespace Dapper.Controllers
{
    public class OneTestController : BTActionBaseController
    {
        [HttpPost]
        public void Run() 
        {

            //OneSqlqer.SelectUser();
            OneSqlqer.InSelect();
            //OneSqlqer.InsertList();
            //OneSqlqer.DataClass();
        }
    }
}