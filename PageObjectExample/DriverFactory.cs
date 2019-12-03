using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectExample
{
    public class DriverFactory
    {
        internal static IWebDriver Get()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}