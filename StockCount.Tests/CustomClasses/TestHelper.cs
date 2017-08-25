using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using OpenQA.Selenium;

namespace StockCount.Tests.CustomClasses
{
    public static class TestHelper
    {
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
