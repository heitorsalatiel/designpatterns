namespace Behavioral.TemplateMethod.Example1
{
    public class ConcreteClass2 : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Primitive Operation 1 Invoked from ConcreteClass2");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Primitive Operation 2 Invoked from ConcreteClass2");
        }

        public override void Hook()
        {
            Console.WriteLine("Hook invoked from ConcreteClass2");
        }
    }
}
