namespace Creational.Singleton
{
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

}
