namespace Behavioral.Visitor.Example2
{
    public class SubtitleElement(string text) : IDocumentElement
    {
        public string Text { get; } = text;

        public void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Operation1()
        {
            return "Concrete Element 1";
        }
    }
}
