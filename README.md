# ASP.NET Delegates And Friends

This project to play a bit with delegates, events and lampda expressions.

## Some Description Notes on what implemented

Quick Delegate definition:
a delegate is a method that knows how to refer(call) other methods.

### //LD TEST002 - nullable

A "Value Type" can't be null! but sometime I need to map a value from Database that could be null, so I can use nullable.
 - DateTime date = null; //LD I get an error because a value type can't be null
 - but I can use NULLABLE: "Nullable<DateTime> date2=null;"
 - - is possible write like this: "DateTime? date2 =null;" 
 - is impossible assign a nullable to a not nullable

Some properties:
 - "HasValue"
 - "GetValueOrDefault"

### //LD TEST006 - generics
Generics allow you to delay the specification of the data type of programming elements in a class or a method, until it is actually used in the program. In other words, generics allow you to write a class or method that can work with any data type.

You write the specifications for the class or the method, with substitute parameters for data types. When the compiler encounters a constructor for the class or a function call for the method, it generates code to handle the specific data type.

### //LD TEST007 - delegates
In the example done he start from a method that process a photo, from this method I call many other method(filters) to set this photo.. the point is: any time that I have to do add a filter, do I need to recompile the method? no!

by using **delegate**, so a pointer to methods with the same signature, everything become extensible

When are delegates useful?
when we are using an event design pattern, the caller doesn't need to access other properties or methods on the object implementing the method.

- Delegates available in framework
  - ACTION (return void)
  - FUNC (return value)

### //LD TEST008 lampda expression, predicate

A **lampda expression** is an anonymus method with:
- no access modifier (public/private etc)
- no name
- no return statement

A **predicate** is a delegate that point to a method that get a "book" in this case and returns a boolean that say if a given condition is satisfied

### //LD TEST009 events and delegates

An **event** is a mechanism to let objects communicate, so when something happen in an object one or more can be then notified. 
 - useful for ubuild loosely coupled application
 - helps extend applications

How to use delagates in pubblicher/subscriber pattern
 - delegate is a "contract" between publicher and subscriber.
 - delegate determines the signature of the subscriber.
 - delegate notify the subscriber

### //LD TEST010 extensions methods

**Definition**: Extension methods enable you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. Extension methods are a special kind of static method, but they are called as if they were instance methods on the extended type. 

Extension methods allow to add method to an existing class without:
- changing its source code, so recompile it 
or
- creating a new class that inherits from it


### Resources
- multithreading
  - https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
  - https://weblogs.asp.net/dixin/functional-csharp-asynchronous-function
- reflection
  - https://www.tutorialspoint.com/csharp/csharp_reflection.htm
- generics
  - https://www.tutorialspoint.com/csharp/csharp_generics.htm
  - https://www.codeproject.com/Articles/47887/C-Delegates-Anonymous-Methods-and-Lambda-Expressio
- Extension Methods
  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods