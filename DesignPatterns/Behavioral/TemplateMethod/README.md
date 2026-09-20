# Template Method

## Definition

Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine
certain steps of an algorithm without changing the algorithm's structure.

## Benefits 

* Code reusability : this is the case if the algorithm must really be common among the concrete classes
* Restructure of the algorithm will be consistent
* Extensibility : you can plugin (hooks) and change exactly what you want to change
* Flexible
* Control and centralization through abstract class
* Single component that should be maintaned and tested in to ensure the core algorithm works - simpler to test, maintain, debug and build

## Drawbacks

* We rely on inheritance : the logic is spreaded out in several classes , it becomes more complex and it can be harder to track what's happening
* The Template Method pattern introduces tight coupling between the base template and its subclasses. When multiple classes rely on a single template method, adapting to evolving requirements becomes difficult.
If a specific subclass requires unique behavior, developers often resort to bloating the base method with complex if/else type-checking logic. This creates a convoluted, fragile template that is notoriously difficult to refactor. 
To mitigate this, a robust Template Method must incorporate hooks at strategic points. These hooks grant subclasses the flexibility to inject custom logic or opt into specific behaviors without altering the core structure.
Ultimately, this pattern is best suited for stable algorithms. If your algorithm is highly dynamic or requires frequent structural modifications, the Template Method is likely the wrong choice—consider alternatives patterns instead.
* It can be challenging to implement it because you have to decide what's going to be a hook, what's going to be primitive, what's going to be in the abstract class,how it's going to escale and how the subclasses are going to use the
abstract class.
* Lack of flexibility : while hooks offer a degree of flexibility by allowing subclasses to extend specific steps, the overarching algorithm remains inherently rigid. Modifying the core template is risky; because it serves as the foundation for multiple subclasses, a structural change designed to satisfy one subclass could easily break or conflict with the others.