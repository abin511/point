﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Pay
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg) : base(msg)
        {
        }
    }
}
