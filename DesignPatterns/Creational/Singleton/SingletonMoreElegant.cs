namespace Creational.Singleton
{
    sealed class SingletonMoreElegant
    {
        private static readonly Lazy<SingletonMoreElegant> _lazyInstance = new(() => new SingletonMoreElegant());

        public static SingletonMoreElegant Instance => _lazyInstance.Value;

        private SingletonMoreElegant()
        {
            Console.WriteLine("Instantiating SingletonMoreElegant");
        }
    }

}
