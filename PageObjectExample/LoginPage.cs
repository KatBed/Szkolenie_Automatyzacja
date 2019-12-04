using System;
using OpenQA.Selenium;

namespace PageObjectExample
{
    internal class LoginPage
    {
        private const string LOGIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net/wp-admin";
        private readonly IWebDriver _browser;

        private LoginPage(IWebDriver browser)
        {
            _browser = browser;
            browser.Navigate().GoToUrl(LOGIN_PAGE_BASE_URL);
        }

        internal static LoginPage Open(IWebDriver browser)
        {
            return new LoginPage(browser);
        }
        internal AdminPage LetsLogIn()
        {
            var userName = _browser.FindElement(By.Id("user_login"));
            userName.SendKeys("automatyzacja");
            var userPassword = _browser.FindElement(By.Id("user_pass"));
            userPassword.SendKeys("auto@Zima2019");
            var userLogIn = _browser.FindElement(By.Id("wp-submit"));
            userLogIn.Click();
            

            return new AdminPage(_browser);

        }
    }
   
}




