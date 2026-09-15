## 1) Characteristics : 
* Single Instance
* Easy global access
* Control initialization
* Private Constructor : private Singleton() {}
* Static Instance Field : private static Singleton _instance;
* Public Static Access Property

## 2) Singleton Pattern vs. DI Singleton

`services.AddSingleton<T>()` makes the DI container treat the class as a singleton by reusing the same instance. However, the class itself lacks native Singleton protections (such as a private constructor). Because the singleton scope is tied to the container, creating multiple `IServiceProvider` instances will bypass this and create multiple instances of the class.

## 3) Benefits

*   **Resource Management:** All the resources used by the class need to be initialized only once. This is especially true for resource-heavy operations.
*   **Controlled access**
*   **Consistent state:** The state is always preserved over the application.
*   **Thread safety**
*   **Lazy initialization**

## 4) Drawbacks

### 4.1) Hidden Dependencies

```csharp
new ServiceA().Foo();

public class ServiceA 
{
    public void Foo() 
    {
        SingletonClass.Instance.DoSomething(); // Here we create a hidden dependency 
    }
}
```

**Solution:** Use Dependency Injection by passing the `SingletonClass` into the constructor of `ServiceA`.

```csharp
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
```

### 4.2) Makes Unit Tests Harder

```csharp
public class ServiceA 
{
    public void Foo() 
    {
        // Singleton class is used and initialized directly which makes testing harder
        SingletonClass.Instance.DoSomething(); 
    }
}
```

*   It makes it harder to mock and to substitute the `SingletonClass` in unit tests, as it's used directly. Moreover, even with dependency injection, it would be hard to test because we do not control the initialization of the `SingletonClass` object.

**Solution 1:** Inject an interface instead and make the `SingletonClass` implement this interface.

```csharp
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
```

**Solution 2:** If you are unable to implement and use an interface, you can use a wrapper around the `SingletonClass` which you can control and abstract away. You then inject this wrapper into `ServiceA`.

```csharp
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
```

### 4.3) Tight Coupling

*   You tie your class to the implementation of another class.
*   **Solution:** Inject an interface instead of the Singleton class directly.

### 5) Single Point of Failure

*   If there is a bug in the Singleton class, it will fail for all the objects using it across the application. Furthermore, we might have to reinitialize the state of the Singleton class, which can be challenging when the same object is used by various other objects.
*   **Solution:** Implement resilient error handling and robust tests to ensure you know how to handle such failures gracefully.
```