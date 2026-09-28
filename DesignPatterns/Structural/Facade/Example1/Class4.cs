namespace Structural.Facade.Example1
{
    public class Class4
    {
        private Class2 Class2 { get; set; }

        public Class4(Class2 class2)
        {
            Class2 = class2;
        }

        public void Operation5(Class3 class3)
        {
            Class2.Operation3();
            class3.Operation4();
            Console.WriteLine("Class 4 - Operation 5");
        }
    }
}
