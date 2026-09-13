using Creational.Singleton;

/*===== 1. Singleton : =====*/

#region 1.0) Characteristics : 
        
/*
        *Single Instance
        * Easy global access
        * Control initialization
        * Private Constructor : private Singleton() {}
        * Static Instance Field : private static Singleton _instance;
        * Public Static Access Property

*/

#endregion

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

#region 1.5) Singleton Pattern vs. DI Singleton:

/* services.AddSingleton<T>() makes the DI container treat the class as a singleton by reusing the same instance.
However, the class itself lacks native Singleton protections (such as a private constructor).
Because the singleton scope is tied to the container, creating multiple IServiceProvider instances will bypass
this and create multiple instances of the class.*/

#endregion

#region 1.6)  Benefits : 

/*
    * Resource Management : all the resources used by the class need to be initialized only once. Specially true for resource-heavy operations.
    * Controlled access
    * Consistent state : the state is always preserved over the application
    * Thread safety
    * Lazy initialization
*/

#endregion

#region 1.7) Drawbacks :

#region 1.7.1) Hidden Dependencies : 

/*
 
new ServiceA().Foo();

public class ServiceA 
{
    public void Foo() 
    {
        SingletonClass.Instance.DoSomething(); //Here we create a hidden dependency 
    }
}

- Solution : The solution is to use Dependency Injection by passing the SingletonClass in the constructor of ServiceA

    new ServiceA(singletonClass).Foo();

    public class ServiceA 
    {
        private readonly SingletonClass _singletonClass;
    
        public ServiceA(SingletonClass singletonClass)
        {
            _singletonClass = singletonClass;
        }

        public void Foo() 
        {
            _singletonClass.DoSomething();
        }
    }

*/

#endregion

#region 1.7.2) Make Unit Tests harder : 

/*
 
public class ServiceA 
{
    public void Foo() 
    {
        SingletonClass.Instance.DoSomething(); //Singleton class is used and initialized directly which makes testing harder
    }
}
        
- It makes the harder to mock and to substitute the SingletonClass in our unit tests, as it's used directly. Moreover, even with
    dependency injection, it would be hard to test, because we do not control the initialization of the SingletonClass object.

- Solution : The solution is to inject an Interface instead and make the SingletonClass to implement this interface.

    public class ServiceA 
    {
        private readonly ISingletonClass _singletonClass;

        public ServiceA(ISingletonClass singletonClass)
        {
            _singletonClass = singletonClass;
        }

        public void Foo() 
        {
            _singletonClass.DoSomething();
        }
    }

- 2nd Solution : If you a unable to implement and use an interface, you can use a wrapper around the SingletonClass which you can control
    and abstract away. Then you inject this wrapper into the ServiceA.

    public class ServiceA 
    {
        private readonly SingletonClassWrapper _singletonClassWrapper;

        public ServiceA(SingletonClassWrapper singletonClassWrapper)
        {
            _singletonClassWrapper = singletonClassWrapper;
        }

        public void Foo() 
        {
            _singletonClassWrapper.DoSomething();
        }
    }

 */

#endregion

#region 1.7.3) Tight Coupling : 

/*
    - You tight you class to the implementation of another class
    
    - Solution : to inject an interface instead of the Singleton class directly.

*/

#endregion

#region 1.7.4) Single point of failure : 

/*
 
- If we have a bug in the Singleton class, it's going to fail for all the objects using the Singleton class over the application. Not only that,
  but we might have to reinitialize the state of the Singleton class, and reinitializing can be challenging when the same object is used from various
  other objects in the application.

- Solution : to have resilient error handling and good tests in place to make sure that you know how to handle such failures.

 */

#endregion

#endregion