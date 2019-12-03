namespace PageObjectExample
{
    internal class ExampleComment
    {
        public ExampleComment()
        {
            Author = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            Content = Faker.Lorem.Paragraph();
        }

        public string Author { get; }//get set każdy moze pobrac wartosc i kazdy moze zmienic
        public string Email { get; }
        public string Content { get; }
    }
}