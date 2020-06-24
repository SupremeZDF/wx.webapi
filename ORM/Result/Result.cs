using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Result
{
    public class Result<T> 
    {
        public int code { get; set; }

        public string msg { get; set; }

        public T data { get; set; } 
    }

    public class Result 
    {
        public int code { get; set; }

        public string msg { get; set; }

        public object data { get; set; }
    }
}
