using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
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

        public void CanAddNewComment()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");

            var latestNote = browser.FindElement(By.CssSelector(".entry-title > a")); //klika w linka i przenosi do nowej strony
            latestNote.Click();

            //var firstNote = browseByElement(By.CssSelector("..entry-title"));
            //var firstNoteUrl = firstNote.FindElement(By.TagName("a"));

            var comment = browser.FindElement(By.Id("comment"));
            var exampleText = Faker.Lorem.Paragraph();
            comment.SendKeys(exampleText);

            var author = browser.FindElement(By.Id("author"));
            var exampleAuthor = Faker.Name.FullName();  //zmienna sxampleauthor
            author.SendKeys(exampleAuthor);

            var email = browser.FindElement(By.Id("email"));
            var exampleEmail = Faker.Internet.Email();
            email.SendKeys(exampleEmail);

            MoveToElement(browser.FindElement(By.CssSelector("div.nav-links")));

            browser.FindElement(By.Id("submit")).Submit();

            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleAuthor) //ma być takie samo ==
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleText);

            Assert.Single(myComments);
        }
            //poniższa linijka służy do przesuwania elementu kiedy nie widać go na stronie
            private void MoveToElement(IWebElement element)
            {
                Actions builder = new Actions(browser);
                Actions moveTo = builder.MoveToElement(element);
                moveTo.Build().Perform();
            }
   
            //Assert.Equal("komentarz dodany przez automat", result.Text);

        public void Dispose() //metoda Dispose która robi quit
        {
            browser.Quit();
        }
    }
}
