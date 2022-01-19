using EAAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAEmployeeTest.PageObjects
{
    class HomePagePO : BasePage
    {
        IWebElement lnkEmployeeList => Driver.FindElement(By.XPath("//*[@class='nav navbar-nav']/li[3]/a"));

        public EmployeePO ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return GetInstanceOf<EmployeePO>();
        }
    }
}
