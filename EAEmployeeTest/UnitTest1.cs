using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using static EAAutoFramework.Base.Browser;

namespace EAEmployeeTest
{
    public class Tests : Base
    {
        string url = "http://eaapp.somee.com/";
        //private IWebDriver _driver;

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver(options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [SetUp]
        public void Setup()
        {
            //driverDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +
            //    "\\EAAutoFramework\\Driver\\chromedriver.exe";
        }

        [Test]
        public void Test1()
        {
            //_driver = new ChromeDriver(options);
            //DriverContext.Driver = new ChromeDriver(options);
            //DriverContext.Driver.Navigate().GoToUrl(url);
            //Login();

            //LoginPO loginPO = new LoginPO();
            //loginPO.ClickLogin();
            //loginPO.Login("admin", "password");

            //HomePagePO homePagePO = new HomePagePO();
            //var employeePO = homePagePO.ClickEmployeeList();
            //employeePO.ClickCreateNew();

            //CurrentPage = homePagePO.ClickEmployeeList();
            //((EmployeePO)CurrentPage).ClickCreateNew();

            string dataFileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(dataFileName);

            LogHelpers.CreateLogFile();

            OpenBrowser(BrowserType.Chrome);
            LogHelpers.Write("Opened the browser");

            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigated to the page");

            CurrentPage = GetInstanceOf<LoginPO>();
            CurrentPage.As<LoginPO>().ClickLogin();
            
            CurrentPage.As<LoginPO>().Login(ExcelHelpers.ReadData(2, "UserName"), ExcelHelpers.ReadData(2, "Password"));

            CurrentPage = GetInstanceOf<HomePagePO>();
            CurrentPage = CurrentPage.As<HomePagePO>().ClickEmployeeList();
            CurrentPage.As<EmployeePO>().ClickCreateNew();
            //CurrentPage.As<EmployeePO>().ClickCreateNew();



            DriverContext.Driver.Close();
        }

        //public void Login()
        //{
        //    LoginPO loginPO = new LoginPO(_driver);
        //}
    }
}