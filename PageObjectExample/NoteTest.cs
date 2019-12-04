using System.Security.Policy;
using Xunit;

namespace PageObjectExample
{
    public class NoteTest : BaseTest
    {
        [Fact]
        public void CanPublishNewNote()
        {
            var startPage = LoginPage.Open(GetBrowser());
            var adminPage = startPage.LetsLogIn();
           

            var testNote = new ExampleNote();
            var newNote = adminPage.AddNote(testNote);
            var notePage = new NotePage(GetBrowser());
            notePage.Open(newNote);
            Assert.True(notePage.Has(testNote));
        }
    } 
}