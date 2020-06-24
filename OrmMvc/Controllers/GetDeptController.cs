using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.model;
using ORM.Result;

namespace OrmMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetDeptController : ControllerBase
    {
        /// <summary>
        /// 获取json数据
        /// </summary>
        [HttpPost]
        public Result<List<GetDeptOutPut>> GetName(List<GetDeptInputDto> getDepts)
        {
            DeptORM deptORM = new DeptORM();
            return new Result<List<GetDeptOutPut>>
            {
                code = 1,
                msg = "成功",
                data = deptORM.GetDeptBmber(getDepts)
            };
        }

        [HttpGet]
        public string A() 
        {
            return "1";
        }
    }
}