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
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");

            var queryBox = browser.FindElement(By.PartialLinkText("ghfjhjhvjhvjh"));
            queryBox.Click();
            var queryBox1 = browser.FindElement(By.Id("comment"));
            queryBox1.Click();
            queryBox1.SendKeys("komentarz dodany przez automat");
            var queryBox2 = browser.FindElement(By.Id("author"));
            queryBox2.SendKeys("Kasia Kasia");
            var queryBox3 = browser.FindElement(By.Id("email"));
            queryBox3.SendKeys("Kasia@Kasia.wp.pl");
            var queryBox4 = browser.FindElement(By.Id("submit"));
            queryBox4.Click();

            //poniższa linijka służy do przesuwania elementu kiedy nie widać go na stronie
            //private void MoveToElement(IWebElement element)
            //{
             //   Actions builder = new Actions (browser)
             //Actions moveTo = builder.MoveToElement(element);
             //moveTo.Build().Perform();
            //}

            Assert.Equal("komentarz dodany przez automat", result.Text);
            
        }

        public void Dispose() //metoda Dispose która robi quit
        {
            browser.Quit();
        }
    }
}
