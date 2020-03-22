using System;

namespace CSharp8Tests
{

    /// <summary>
    /// Nullable Reference Type test
    /// https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/nullable-reference-types
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TEST ONE
            var test = new personTwo ("luca", "luchino");
            var testTwo = new personTwo("luca", null); //no warning, tryint to assign a null to a nullable
            var testThree = new personTwo(null, null); //In this case I do assign a null to a not nullable, I get the warning

            //TEST DECLARATION TWO
            personTwo testNull = new personTwo();
            testNull.Surname = null; //In this case I do assign a null to a nullable, no warning
            testNull.Name = null; //In this case I do assign a null to a not nullable, I get the warning


        }
    }

    //This class just to test new C#8 class constructor sintax
    public class person{
        private string _name { get; }
        private string _surname { get; }

        public person(string name, string surname) => (_name, _surname) = (name, surname);
    }

    //This class to check nullable reference 
        public class personTwo
        {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string? _surname;
            //the below example checks upfront if a "null" is assigned to "Surname" and in case throw straight an exception
            public string? Surname
            {
            get => _surname;
            set => _surname = value ?? throw new ArgumentNullException(paramName: nameof(value), message: "message");
            }

        public personTwo() {

        }
        public personTwo(string name, string? surname)
        {
            //A best practise is to check if something is null and then continue with the business logic I have
            if (name is null)
                throw new ArgumentNullException(paramName: nameof(surname), message: "message");
            if (surname is null)
                throw new ArgumentNullException(paramName: nameof(surname), message: "message");

            //another approach is to check as below, the compiler will not complain with any warning
            this._name = name ?? "test";

            _surname = surname;
        }
    }
}
