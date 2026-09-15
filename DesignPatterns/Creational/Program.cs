using Creational.Singleton;

/*===== 1. Singleton : =====*/

#region 1.1) Naive Singleton - Fails in Multithread scenarios :

Console.WriteLine("==== Naive Singleton =====");
    Console.WriteLine("Before accessing instance");
    NaiveSingleton singleton1 = NaiveSingleton.Instance;
    Console.WriteLine("After accessing instance");
    NaiveSingleton singleton2 = NaiveSingleton.Instance;
    Console.WriteLine();

#endregion

#region 1.2) Multithread :

    Console.WriteLine("===== Singleton with Multithread support =====");
    ParallelEnumerable.Range(0,1000)
    .ForAll(_ =>
    {
        SingletonWithMultithreadSupport singleton = SingletonWithMultithreadSupport.Instance;
    });
    Console.WriteLine();

#endregion

#region 1.3) More elegant way : 

    Console.WriteLine("===== Singleton with Multithread support and more elegant (.NET) =====");
    ParallelEnumerable.Range(0,1000)
    .ForAll(_ =>
    {
        SingletonMoreElegant singleton = SingletonMoreElegant.Instance;
    });
    Console.WriteLine();

#endregion

#region 1.4) Tricky Singleton : 

    Console.WriteLine("===== Tricky Singleton with Multithread =====");
    ParallelEnumerable.Range(0, 1000)
    .ForAll(_ =>
    {
        TrickySingleton singleton = TrickySingleton.Instance;
    });
    Console.WriteLine();

#endregion