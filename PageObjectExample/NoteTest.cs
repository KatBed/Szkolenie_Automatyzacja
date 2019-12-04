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
            var NewNote = adminPage.AddNote(testNote); //dodajemy notatkę

           


        }
    } 
}

// zalogowac sie do panelu administracyjnego (wykonane)
// utworzyc notatke
// wylogowac
// nowa notatka jest opublikowana