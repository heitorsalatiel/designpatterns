namespace Behavioral.Visitor.Example1
{
    public class ConcreteElement1 : Element
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Operation1()
        {
            return "Concrete Element 1";
        }
    }
}
