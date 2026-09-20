namespace Behavioral.Visitor.Example1
{
    public class ConcreteVisitor1 : IVisitor
    {
        public void Visit(ConcreteElement1 element)
        {
            var result = element.Operation1();
            Console.WriteLine($"Concrete Visitor 1 : {result}");
        }

        public void Visit(ConcreteElement2 element)
        {
            var result = element.Operation2();
            Console.WriteLine($"Concrete Visitor 1 : {result}");
        }
    }
}
