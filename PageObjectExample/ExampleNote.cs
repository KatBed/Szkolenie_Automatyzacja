using System;

namespace PageObjectExample
{
    internal class ExampleNote
    {
        public ExampleNote()
        {
            Title = Faker.Lorem.Sentence();
            Text = Faker.Lorem.Paragraph();

        }
        public string Title { get; }
        public string Text { get; }
    }
}