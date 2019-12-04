using Xunit;

namespace PageObjectExample //pamiętać o dodawaniu nugetów
{
    public class CommentTests //nazwy plików i nazwy klas powinny byc takie same
    {
        [Fact]
        public void CanAddNewCommentToLatestNote()
        {
            var blogStartPage = MainPage.Open(); //c# czytamy od prawej do lewej Open-metoda fabryczna(tworzenie obiektów)
            var note = blogStartPage.NavigateToNewestNote();
            var exampleComment = new ExampleComment();
            var noteWithComment = note.AddComment(exampleComment);

            Assert.True(noteWithComment.Has(exampleComment)); //tu moze byc Asercja, nie w klasie
        }
    }
}
