using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Automatyzacja
{
    public class GoogleTests : IDisposable //implementuje IDisposable
    {
        IWebDriver browser; //scope =zasięg widoczności zmiennej = (int x); browser ma byc widoczny w całym kodzie. domyślnie jest private
        public GoogleTests()
        {
            browser = new ChromeDriver(); //konstruktor
        }
        [Fact]

        public void CanGoogleWeatherForWarsaw()
        {
            browser.Navigate().GoToUrl("https://google.com");

            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.Click();
            queryBox.SendKeys("pogoda Warszawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);
        }

        public void Dispose() //metoda Dispose która robi quit
        {
            browser.Quit();
        }
    }
}
