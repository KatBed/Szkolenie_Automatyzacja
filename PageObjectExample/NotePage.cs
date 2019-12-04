using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;

namespace PageObjectExample //ta klasa tylko i wyłącznie rozmawia z Selenium
{
    internal class NotePage
    {
        private IWebDriver _browser;


        public NotePage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal NotePage ExampleNote(ExampleComment exampleComment)//3 zmienne, klasa "ExampleComment" jest kontenerem na 3 zmienne, przekazujemy email, komentarz i autora
        {
            var comment = _browser.FindElement(By.Id("comment"));
            comment.SendKeys(exampleComment.Content);

            var author = _browser.FindElement(By.Id("author"));
            author.SendKeys(exampleComment.Author);

            var email = _browser.FindElement(By.Id("email"));
            email.SendKeys(exampleComment.Email);

            MoveToElement(_browser.FindElement(By.CssSelector("div.nav-links")));

            _browser.FindElement(By.Id("submit")).Submit();

            return new NotePage(_browser);
        }

        internal bool Has(ExampleNote testNote)
        {
            var title = _browser.FindElement(By.CssSelector("h1.entry-title"));
            var content = _browser.FindElement(By.CssSelector(".entry-content"));


            return testNote.Title == title.Text && testNote.Text == content.Text;
        }

        internal void Open(string noteUrl)
        {
            _browser.Navigate().GoToUrl(noteUrl);
        }

        internal bool Has(ExampleComment exampleComment) 
        {
            var comments = _browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author) //ma być takie samo ==
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleComment.Content);

            return myComments.Count() == 1;//Assercja! 

        }
        private void MoveToElement(IWebElement element) //funkcja
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }


    }
}