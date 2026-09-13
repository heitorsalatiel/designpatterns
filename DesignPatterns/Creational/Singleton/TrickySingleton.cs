namespace Creational.Singleton
{
    sealed class TrickySingleton()
    {
        public static string SomeProperty => "SomeValue";

        public static TrickySingleton Instance => TrickySingletonInstanceHolder.Instance;

        private class TrickySingletonInstanceHolder
        {
            internal static TrickySingleton Instance { get; } = new();

            static TrickySingletonInstanceHolder() { }
        }

        /*
         While a static constructor lazy-loads your static members, it initializes them all at once rather than independently. 
         This means that simply accessing SomeProperty will inadvertently trigger the creation of your TrickySingleton instance. 
         The trick to avoiding this is to hold the instance inside a nested class (TrickySingletonInstanceHolder). 
         Since the nested class has its own static constructor, its fields will remain uninitialized until you actually access 
         the singleton instance directly. This is Lazy loaded and Thread Safe
        */
        static TrickySingleton() 
        {
            Console.WriteLine("Instantiating TrickySingleton");        
        }
    }

}
