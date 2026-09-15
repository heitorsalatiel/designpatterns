namespace Behavioral.Visitor.Example2
{
    public interface IDocumentVisitor
    {
        void Visit(TitleElement element);
        void Visit(SubtitleElement element);
        void Visit(ContentElement element);
    }
}
