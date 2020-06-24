using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Result
{
    public class enumList
    {
        public static List<deptDto> deptDtos = new List<deptDto>()
        {
           new deptDto{ Id=1,Name="1"},
            new deptDto{ Id=2,Name="2"},
             new deptDto{ Id=3,Name="3"},
              new deptDto{ Id=4,Name="4"},
               new deptDto{ Id=5,Name="5"},
                new deptDto{ Id=6,Name="6"}
        };

    }

    public class deptDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
