using Xunit;

namespace PageObjectExample //pamiętać o dodawaniu nugetów
{
    public class CommentTests : BaseTest//nazwy plików i nazwy klas powinny byc takie same
    {
        [Fact]
        public void CanAddNewCommentToLatestNote()
        {
            var startPage = MainPage.Open(GetBrowser()); //c# czytamy od prawej do lewej Open-metoda fabryczna(tworzenie obiektów)
            var note = startPage.NavigateToNewestNote();
            var testComment = new ExampleComment();
            var noteWithComment = note.ExampleNote(testComment);

            Assert.True(noteWithComment.Has(testComment)); //tu moze byc Asercja, nie w klasie
        }
    }
}

//1. najpierw otwieramy przeglądarkę
//2. znajdyjemy komentarze
//3. dodajemy komentarz



//to jest główna klasa testu, od niej zaczynamy i dajemy nowe klasy wnowych oknach.