namespace Behavioral.TemplateMethod.Example1
{
    public class ConcreteClass : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Primitive Operation 1 Invoked from ConcreteClass1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Primitive Operation 2 Invoked from ConcreteClass1");
        }
    }
}
