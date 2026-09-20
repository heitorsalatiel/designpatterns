namespace Behavioral.Visitor.Example1
{
    public class ConcreteElement2 : Element
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Operation2()
        {
            return "Concrete Element 2";
        }
    }
}
