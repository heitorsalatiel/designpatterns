namespace Behavioral.Visitor.Example1
{
    public interface Element
    {
        void Accept(IVisitor visitor);
    }
}
