using System;
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
            var noteWithComment = note.AddComment(testComment);

            Assert.True(noteWithComment.Has(testComment)); //tu moze byc Asercja, nie w klasie
        }
        
    }
}
