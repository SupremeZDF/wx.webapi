﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Applications.Implement
{
    public class TestService3 : IBaseTestService
    {
        private string str { get; set; }
        public TestService3()
        {
            str = Guid.NewGuid().ToString();
        }
        public string GetString()
        {
            return str;
        }
    }
}
