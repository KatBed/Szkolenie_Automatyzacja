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
            var notePage = new NotePage(GetBrowser()); //var bo zwraca stringa (link)
            notePage.Open(newNote);
            Assert.True(notePage.Has(testNote)); //sprawdzamy czy ta notatka ma notatke wpisana notatke przez nas wczesniej HAS=czy ma
        }
    }
}
