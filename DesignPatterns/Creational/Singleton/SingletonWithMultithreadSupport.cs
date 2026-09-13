namespace Creational.Singleton
{
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

}
