using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndFriendsTest.Suppost_Classes
{
    class Base { }
    class Derived : Base { }

    //INVARIANT
    /// <summary>
    /// Invariant is what our “normal” generics or delegates might look like.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IProcessor<T> 
    {}

    class Processor<T> : IProcessor<T>
    {}


}
