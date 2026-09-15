namespace Behavioral.Visitor.Example2
{
    public interface IDocumentElement
    {
        void Accept(IDocumentVisitor visitor);
    }
}
