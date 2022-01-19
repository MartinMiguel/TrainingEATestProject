using EAAutoFramework.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.PageObjects
{
    class LoginPO : BasePage
    {
        //public LoginPO(IWebDriver driver) : base (driver)
        //{
        //}

        //IWebElement lnkLogin => _driver.FindElement(By.Id("loginLink"));
        IWebElement lnkLogin => Driver.FindElement(By.Id("loginLink"));

        //IWebElement txtUserName => _driver.FindElement(By.Name("UserName"));
        IWebElement txtUserName => Driver.FindElement(By.Name("UserName"));

        //IWebElement txtPassword => _driver.FindElement(By.Name("Password"));
        IWebElement txtPassword => Driver.FindElement(By.Name("Password"));

        //IWebElement btnLogin => _driver.FindElement(By.XPath("//input[contains(@class, 'btn')]"));
        IWebElement btnLogin => Driver.FindElement(By.XPath("//input[contains(@class, 'btn')]"));

        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }

        public void ClickLogin()
        {
            lnkLogin.Click();
        }

    }
}
