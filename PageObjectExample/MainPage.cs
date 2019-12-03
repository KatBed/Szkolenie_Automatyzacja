using System;

namespace PageObjectExample
{
    internal class MainPage
    {
        internal static MainPage Open()
        {
            return new MainPage();
        }

        internal NotePage NavigateToNewestNote()
        {
            return new NotePage();
        }
    }
}