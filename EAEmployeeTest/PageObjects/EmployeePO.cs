using EAAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAEmployeeTest.PageObjects
{
    class EmployeePO : BasePage
    {

        //public EmployeePO(IWebDriver driver) : base (driver)
        //{
        //}

        //IWebElement txtboxSearchName => _driver.FindElement(By.Name("searchTerm"));
        IWebElement txtboxSearchName => Driver.FindElement(By.Name("searchTerm"));

        IWebElement btnkCreateNew => Driver.FindElement(By.XPath("//input[@name=\"searchTerm\"]/preceding::a[1]"));

        public CreateEmployeePO ClickCreateNew()
        {
            btnkCreateNew.Click();
            return GetInstanceOf<CreateEmployeePO>();
        }

    }
}
