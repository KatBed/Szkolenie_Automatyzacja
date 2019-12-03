using System;

namespace PageObjectExample
{
    internal class NotePage
    {
        public NotePage()
        {
        }

        internal NotePage AddComment(ExampleComment exampleComment)
        {
            return new NotePage();
        }

        internal bool Has(ExampleComment exampleComment)
        {
            return false; //aby dało sie skompilować i uruchomić
        }
    }
}