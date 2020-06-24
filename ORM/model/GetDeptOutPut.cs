using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.model
{
    public class GetDeptOutPut
    {
        public string DepetName { get; set; }

        public string DomNameID { get; set; }

        public string DeptType { get; set; }

        public object DeptObject { get; set; }
    }

    public class deptDto
    {
        public long Id { get; set; }

        public string DeptName { get; set; }

        public int ParentDeptId { get; set; }


        public string remark { get; set; }
    }

    public class TreeDto
    {
        public long Id { get; set; }

        public string text { get; set; }

        public object childs { get; set; }
    }
}
