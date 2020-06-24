using System;
using System.Collections.Generic;
using System.Text;
using ORM.Result;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace ORM.model
{
    public class DeptORM : BaseModelSql
    {
        public List<GetDeptOutPut> GetDeptBmber(List<GetDeptInputDto> gets)
        {

            //for (int a=0, b="1 ; a < 12; a++) 
            //{

            //}

            using (var con = GetSqlConnection())
            {
                List<GetDeptOutPut> getDepts = new List<GetDeptOutPut>();
                foreach (var i in gets)
                {
                    GetDeptOutPut getDeptOutPut = new GetDeptOutPut();
                    getDeptOutPut.DomNameID = i.DeptDomID;
                    getDeptOutPut.DepetName = i.DeptName;
                    getDeptOutPut.DeptType = i.DeptType;

                    switch (i.DeptType)
                    {
                        case "enum":
                        case "combox":
                            getDeptOutPut.DeptObject = enumList.deptDtos;
                            break;
                        case "comtree":
                            getDeptOutPut = GetDeptOutPut(getDeptOutPut, con, i.DeptName);
                            break;
                        default:
                            break;

                    }
                    getDepts.Add(getDeptOutPut);
                }
                return getDepts; 
            }
        }

        public GetDeptOutPut GetDeptOutPut(GetDeptOutPut getDeptOutPut, SqlConnection sqlConnection, string deptName)
        {
            switch (deptName)
            {
                case "部门":
                    {
                        var sql = @"select a.Id,a.ParentDeptId,a.DeptName,(case when a.ParentDeptId=0 then 'isFiest' else '' end) remark from Sys_Depts as a";
                        var data = sqlConnection.Query<deptDto>(sql).ToList();
                        getDeptOutPut.DeptObject = GetTreesDto(data);
                        break;
                    }
                case "催收部门":
                    {
                        var sql = @"with temp as(select top(1) Id,ParentDeptId,DeptName ,cast('isFiest' AS nvarchar(50)) remark from Sys_Depts where DeptName='电催部'
                                union all select b.Id,b.ParentDeptId,b.DeptName,cast('isFirst' AS nvarchar(50)) remark from Sys_Depts as b inner join 
                                temp as c on b.ParentDeptId=c.Id) 
                                select a.Id,a.ParentDeptId,a.DeptName,a.remark from temp as a
                                ";
                        var list = sqlConnection.Query<deptDto>(sql).ToList();
                        getDeptOutPut.DeptObject = GetTreesDto(list);
                        break;
                    }

                case "外勤部门":
                    {
                        var sql = @"with temp as(select Id,ParentDeptId,DeptName,cast('isFiest'as nvarchar(50))remark  from Sys_Depts where DeptName='外勤部'
                                union all select b.Id,b.ParentDeptId,b.DeptName,cast(''as nvarchar(50))remark  from Sys_Depts as b 
                                inner join temp as a on b.ParentDeptId=a.Id)
                                select a.Id,a.ParentDeptId,a.DeptName,a.remark from temp as a";
                        var list = sqlConnection.Query<deptDto>(sql).ToList();
                        getDeptOutPut.DeptObject = GetTreesDto(list);
                        break;
                    }
                default:
                    break;
            }
            return getDeptOutPut;
        }

        public List<TreeDto> GetTreesDto(List<deptDto> dtos)
        {
            List<TreeDto> trees = new List<TreeDto>();
            if (dtos.Count == 0 || dtos == null)
            {
                return trees;
            }
            var dto = dtos.Where(i => i.remark == "isFiest").ToList();
            foreach (var i in dto)
            {
                TreeDto treeDto = new TreeDto();
                treeDto.Id = i.Id;
                treeDto.text = i.DeptName;
                var t = dtos.Where(s => s.ParentDeptId == i.Id).ToList();
                if (t.Count > 0)
                {
                    treeDto.childs = GetTreeDtos(dtos, i);
                }
                trees.Add(treeDto);
            }
            return trees;
        }

        public List<TreeDto> GetTreeDtos(List<deptDto> dtos, deptDto dept)
        {
            List<TreeDto> trees = new List<TreeDto>();
            var list = dtos.Where(s => s.ParentDeptId == dept.Id);
            foreach (var i in list)
            {
                TreeDto treeDto = new TreeDto();
                treeDto.Id = i.Id;
                treeDto.text = i.DeptName;
                var chird = dtos.Where(j => j.ParentDeptId == i.Id).ToList();
                if (chird.Count > 0)
                {
                    treeDto.childs = GetTreeDtos(dtos, i);
                }
                trees.Add(treeDto);
            }
            return trees;
        }
    }
}
