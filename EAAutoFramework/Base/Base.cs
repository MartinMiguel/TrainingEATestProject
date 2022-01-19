using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAAutoFramework.Base
{
    public class Base
    {
        public BasePage CurrentPage { get; set; }

        protected TPage GetInstanceOf<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                Driver = DriverContext.Driver
            };

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
