using OpenQA.Selenium;
using System;

namespace PageObjectExample
{
    internal class MainPage
    {
        private const string MAIN_PAGE_BASE_URL = "https://automatyzacja.benedykt.net";
        private readonly IWebDriver browser; //lub _browser (propertis wewnątrz klasy z _)

        private MainPage(IWebDriver browser)
        {
            this.browser = browser; //lub dawać tu podłoge _  (_browser zamiast słowa this)
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal static MainPage Open()
        {
            return new MainPage(DriverFactory.Get());
        }

        internal NotePage NavigateToNewestNote()
        {
            var latestNote = browser.FindElement(By.CssSelector(".entry-title > a")); //klika w linka i przenosi do nowej strony
            latestNote.Click();

            return new NotePage();
        }
    }
}