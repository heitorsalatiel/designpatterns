namespace Behavioral.Visitor.Example1
{
    public class ConcreteVisitor2 : Visitor
    {
        public void Visit(ConcreteElement1 element)
        {
            var result = element.Operation1();
            Console.WriteLine($"Concrete Visitor 2 : {result}");
        }

        public void Visit(ConcreteElement2 element)
        {
            var result = element.Operation2();
            Console.WriteLine($"Concrete Visitor 2 : {result}");
        }
    }
}
