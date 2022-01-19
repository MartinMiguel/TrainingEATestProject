using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAAutoFramework.Base
{
    public static class DriverContext
    {
        public static IWebDriver _driver;

        public static IWebDriver Driver {
            get{
                return _driver;
            }
            set
            {
                _driver = value;
            } 
        }

        public static Browser Browser { get; set; }
    }
}
