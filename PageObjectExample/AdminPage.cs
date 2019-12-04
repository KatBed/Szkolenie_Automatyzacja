using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

            //var newTitle = _browser.FindElement(By.Id("title"));
            //newTitle.SendKeys("To są moje wypociny");

            //var newText = _browser.FindElement(By.Id("content"));
            //newText.SendKeys("To jest tekst z wypocinTo jest tekst z wypocinTo jest tekst z wypocinTo jest tekst z wypocin");

            //WaitForClickable(By.Id("publish"), 5);

            var noteTitle = _browser.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();

            var titleElement = _browser.FindElement(By.Id("title"));
            titleElement.SendKeys(testNote.Title);

            _browser.FindElement(By.Id("content-html")).Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);

            var contentElement = _browser.FindElement(By.Id("content"));
            contentElement.SendKeys(testNote.Text);

            var publishButton = _browser.FindElement(By.Id("publish"));
            publishButton.Click();

            WaitForClickable(By.Id("publish"), 5);

            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);

            var postUrl = _browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = postUrl.GetAttribute("href");

            var newLogOut = _browser.FindElement(By.Id("wp-admin-bar-my-account"));
            MoveToElement(newLogOut);
            WaitForClickable(By.PartialLinkText("Wyloguj się"), 5);

            var newLogOut2 = _browser.FindElement(By.PartialLinkText("Wyloguj się"));
            newLogOut2.Click();

            return url;


        }
        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        internal void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        internal void MoveToElement(By selector)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element);
        }
        internal void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }

}