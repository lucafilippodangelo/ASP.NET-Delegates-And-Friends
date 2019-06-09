using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    //LD "generics" have a parameter, to specify inside "angle brackets"
    //LD it is for "template" or "Type"
    class GenericListTest<T>
    {
        //LD IMPORTANTE manca una prima parte di dichiarazione, dove dichiaro una lista di tipo "T"
        List<T> myLIst = new List<T>();

        public void Add(T value)//LD we don't know who is "T", the consumer of this class will specify that
        {
            myLIst.Add(value);
        }

        public T this[int index]
        {
            get { return myLIst[index]; }
        }

    }
}
 