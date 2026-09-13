using Creational;

/*===== 1. Singleton : =====*/

#region A) Naive Singleton - Fails in Multithread scenarios :

    Console.WriteLine("==== Naive Singleton =====");
    Console.WriteLine("Before accessing instance");
    NaiveSingleton singleton1 = NaiveSingleton.Instance;
    Console.WriteLine("After accessing instance");
    NaiveSingleton singleton2 = NaiveSingleton.Instance;
    Console.WriteLine();

#endregion

#region B) Multithread :

    Console.WriteLine("===== Singleton with Multithread support =====");
    ParallelEnumerable.Range(0,1000)
    .ForAll(_ =>
    {
        SingletonWithMultithreadSupport singleton = SingletonWithMultithreadSupport.Instance;
    });
    Console.WriteLine();

#endregion

#region C) More elegant way : 

    Console.WriteLine("===== Singleton with Multithread support and more elegant (.NET) =====");
    ParallelEnumerable.Range(0,1000)
    .ForAll(_ =>
    {
        SingletonMoreElegant singleton = SingletonMoreElegant.Instance;
    });
    Console.WriteLine();

#endregion

#region D) Tricky Singleton : 

    Console.WriteLine("===== Tricky Singleton with Multithread =====");
    ParallelEnumerable.Range(0, 1000)
    .ForAll(_ =>
    {
        TrickySingleton singleton = TrickySingleton.Instance;
    });
    Console.WriteLine();

#endregion

#region E) Singleton Pattern vs. DI Singleton:

    /* services.AddSingleton<T>() makes the DI container treat the class as a singleton by reusing the same instance.
    However, the class itself lacks native Singleton protections (such as a private constructor).
    Because the singleton scope is tied to the container, creating multiple IServiceProvider instances will bypass
    this and create multiple instances of the class.*/

#endregion