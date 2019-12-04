using Xunit;

namespace PageObjectExample
{
    public class NoteTest : BaseTest
    {
        [Fact]
        public void CanPublishNewNote()
        {
            var startPage = LoginPage.Open(GetBrowser());
            startPage.LetsLogIn();

            var note = new ExampleNote();


        }
    } 
}




// zalogowac sie do panelu administracyjnego (wykonane)
// utworzyc notatke
// wylogowac
// nowa notatka jest opublikowana