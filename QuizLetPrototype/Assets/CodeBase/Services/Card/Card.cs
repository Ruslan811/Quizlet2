namespace CodeBase.Services.Card
{
    public class Card
    {
        public string Term { get; }
        public string Definition { get; }

        public Card(string term, string definition)
        {
            Term = term;
            Definition = definition;
        }
    }
}