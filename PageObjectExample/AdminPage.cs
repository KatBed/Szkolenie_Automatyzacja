using OpenQA.Selenium;

namespace PageObjectExample
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }
    }
}