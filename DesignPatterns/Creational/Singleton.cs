namespace Creational
{
    /// <summary>
    /// Characteristics : 
    ///     * Single Instance
    ///     * Easy global access
    ///     * Control initialization
    ///     * Private Constructor : private Singleton() {}
    ///     * Static Instance Field : private static Singleton _instance;
    ///     * Public Static Access Property
    /// </summary>

    sealed class NaiveSingleton
    {
        private static NaiveSingleton _instance = default!;

        public static NaiveSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NaiveSingleton();
                }

                return _instance;
            }
        }

        private NaiveSingleton()
        {
            Console.WriteLine("Instantiating NaiveSingleton");
        }
    }

    sealed class SingletonWithMultithreadSupport
    {
        private static SingletonWithMultithreadSupport _instance = default!;
        private static object _lock = new();

        public static SingletonWithMultithreadSupport Instance { 
            get
            {
                /* Double check locking : locking everytime we need to instantiate the class might be expensive, as multiple threads might have to wait
                   for each other everytime they try to access the instance of the class. We are only insterested in locking the instance for the first time.
                   Once the class instance is created, the further access can be freely accessible, being the lock not needed this way. */ 
                if(_instance == null)
                {
                    Console.WriteLine("Locking...");

                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonWithMultithreadSupport();
                        }
                    }
                }

                return _instance;
            }
        }

        private SingletonWithMultithreadSupport() 
        {
            Console.WriteLine("Instantiating SingletonWithMultithreadSupport");
        }
    }

    sealed class SingletonMoreElegant
    {
        private static readonly Lazy<SingletonMoreElegant> _lazyInstance = new(() => new SingletonMoreElegant());

        public static SingletonMoreElegant Instance => _lazyInstance.Value;

        private SingletonMoreElegant()
        {
            Console.WriteLine("Instantiating SingletonMoreElegant");
        }
    }

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
