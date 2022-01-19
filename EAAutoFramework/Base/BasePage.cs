using OpenQA.Selenium;

namespace EAAutoFramework.Base
{
    //abstract class cannot be instantiated but can be subclassed. Use abstract for class to be
    //implented or override
    public abstract class BasePage : Base
    {
        public IWebDriver Driver { get; set; }
        //public IWebDriver driver { get; set; }
   
        //public BasePage(IWebDriver driver)
        public BasePage()
        {
            this.Driver = DriverContext.Driver;
            //this.driver = DriverContext.Driver;
        }
    }
}
