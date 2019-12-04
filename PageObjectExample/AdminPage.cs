using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectExample
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal string AddNote(ExampleNote testNote) // void aby nic nie zwracał
        {
            var newNote = _browser.FindElement(By.LinkText("Wpisy"));
            newNote.Click();
            var newPost = _browser.FindElement(By.LinkText("Dodaj nowy"));
            newPost.Click();

            var newTitle = _browser.FindElement(By.Id("title"));
            newTitle.SendKeys("To są moje wypociny");

            var newText = _browser.FindElement(By.Id("content"));
            newText.SendKeys("To jest tekst z wypocinTo jest tekst z wypocinTo jest tekst z wypocinTo jest tekst z wypocin");
       
            WaitForClickable(By.Id("publish"),5);

            var newPublish = _browser.FindElement(By.Id("publish"));
            newPublish.Click();

            return "";
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}