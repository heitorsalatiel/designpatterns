namespace Behavioral.Visitor.Example1
{
    public interface Visitor
    {
        void Visit(ConcreteElement1 element);
        void Visit(ConcreteElement2 element);
    }
}
