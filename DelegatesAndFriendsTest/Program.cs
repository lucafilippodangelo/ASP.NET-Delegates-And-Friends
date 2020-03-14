using AdvancedCSharp;
using DelegatesAndFriendsTest.UsefulClasses;
using System;
using System.Linq;
using ExtensionMethodsLd;
using System.Collections.Generic;
using DelegatesAndFriendsTest.Suppost_Classes;
using DelegatesAndFriendsTest.GenericsSupportClasses;

namespace DelegatesAndFriendsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test007();
            Test008();
            Test009();
            //Test010();
            //Test011();
            //Test012();

            //Test006Bis();
            Console.ReadKey();
        }//LD Main

        #region region testing methods

        //LD linq
        private static void Test001()
        {
            LinqTests aLinqTestInstance = new LinqTests();
            aLinqTestInstance.LastExtensionMethod();
        }


        //LD TEST002 - nullable
        private static void Test002()
        {
            NullableTests nullablin = new NullableTests();
            nullablin.launchTests();
        }


        //LD dynamic
        private static void Test003()
        {
            dynamic anObject = "ld";
            //LD we have the possibility to check if the method really exist at runtime, actually we skip the compiler check in the moment we write code
            anObject.Optimize();

            //LD with dynamic is possible assign the type of "name" dinamically, it depend on the assignement
            dynamic name = "ld";
            name = 10;

            //LD the "var" become automatically a dynamic!
            dynamic a = 1;
            dynamic b = 2;
            var c = a + b;
        }


        //LD exceptions
        private static void Test004()
        {
            try
            {
                ExceptionHandlingTests anInstance = new AdvancedCSharp.ExceptionHandlingTests();
                anInstance.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroExceprion occurred");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("ArithmeticException occurred");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred");
            }
        }


        //LD custom exception
        private static void Test005()
        {
            //LD "YoutubeException.cs" and "YoutubeApi.cs"
            try
            {
                YoutubeApi aClassInstance = new YoutubeApi();
                aClassInstance.GetVideos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// LD TEST006 - generics
        /// if for example I have two list, one of "int" and the second of "Book", and I want 
        /// just ADD AN ITEM IN BOTH THE LISTS, I DON'T NEED OF TWO SEPARATED CLASSES
        /// </summary>
        private static void Test006()
        {
            //here we define the type of list, IT'S THE SAME LIKE WE USUALLY DO HERE: "var bla = new List<int>();"
            var numbers = new GenericListTest<int>(); 
            numbers.Add(23);// automatically it's suggested to pass an "int" parameter

            //LD we can use the same approach for a list of books, just by CHANGING the TEMPLATE PARAMETER
            var books = new GenericListTest<Book>();
            books.Add(new Book());
        }

        /// <summary>
        /// Example of a good use of generics
        /// the class "Car" will have defined at runtime two chain of nested objects.
        /// I can define the object subtypes as I prefer at runtime.
        /// I can pass a generic "ICar" as a parm in any method and use the operator "is" to detect inner object type
        /// </summary>
        private static void Test006Bis()
        {
            Car<RubberTyre, Chassy> carRubberTyreChassy = new Car<RubberTyre, Chassy> {   ACarAttribute = "some car attribute",
                                                                                          aChassy = new Chassy { Model = "chassy model" } ,
                                                                                          aTyre = new RubberTyre {  Model = "rubber tyre model"} };

            Car<SpecialTyre,SpecialChassy> carRubberSpecialTyreSpecialChassy = new Car<SpecialTyre, SpecialChassy>
                                                                                        {
                                                                                            ACarAttribute = "some car attribute",
                                                                                            aChassy = new SpecialChassy { Model = "chassy model" , MaterialComposition = "special tyre material Composition"  },
                                                                                            aTyre = new SpecialTyre { Model = "rubber tyre model" , MaterialComposition = "special chassy material Composition" }
                                                                                        };

            ss(carRubberTyreChassy);
            ss(carRubberSpecialTyreSpecialChassy);

        }

        public static void ss(ICar test)
        {
            if (test is Car<RubberTyre, Chassy>)
            {
                Console.WriteLine("That is a: " + "Car<RubberTyre, Chassy>");
            }
            if (test is Car<SpecialTyre, SpecialChassy>)
            {
                Console.WriteLine("That is a: " + "Car<SpecialTyre,SpecialChassy> ");
            }

        }

        //LD TEST007 - delegates
        private static void Test007()
        {
            //STEP001 this in a class with methods
            var filters = new photoFilter();

            //STEP002 as a first step I'm assigning the method "ApplyBrightness" to the delegate "Action<Photo>". They both have the same signature.
            //note that "ApplyBrightness" takes in input the same type specified in the delegate
            Action<Photo> filterHandler = filters.ApplyBrightness;
            
            //STEP003 adding to the delegate a second method with identical signature
            filterHandler += filters.ApplyContrast;

            //STEP004 then I pass to an instance to a dummy class my delegate
            var aPhotoProcessorInstance = new PhotoProcessor();
            aPhotoProcessorInstance.Process(filterHandler);
        }


        //LD TEST008 lampda expression, predicate
        private static void Test008()
        {
            // lampdaExpression sintax: "args => expression" 
            // the system deledate takes in input two "int" and returns a string -> "Func<int, int, string>"
            // we must specify the two input args -> "(numberOne, numberTwo)"
            Func<int, int, string> myDelegateName = (numberOne, numberTwo) => (numberOne * numberTwo).ToString();
            // C, then we call it
            string ldTest = (myDelegateName(4,3));

            //--------------------------------------------------------

            //PREDICATE
            // LD_A, In this second example, we want return the books cheaper than 10 dolars
            // LD_B, the traditional way:
            var books = new BookRepository().GetBooks();

            // LD_C, a PREDICATE its a DELEGATE that point to a method that get a "book" in this case and RETURN a boolean that say if a given condition is satisfied
            // in this case I can call it like this:
            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            // LD_D, by using LAMPDA EXPRESSION
            var cheapBooks2 = books.FindAll(b => b.price < 10);

            //--------------------------------------------------------

            //TEST ON GENERIC
            string doSomething<T>(T theInput)
            {
                return theInput.GetType().ToString();
            }
            var ddd = doSomething(1);

            //--------------------------------------------------------

            //TEST ON  EXPRESSION

            Func<int, int> square = x => x * x;
            var aNumber = square(5);

            //LD I will package my expression "x => x * x" as an object 
            System.Linq.Expressions.Expression<Func<int, int>> myExpression = x => x * x;
            var anExpression = myExpression;

            int[] numbers = { 2, 3, 4, 5 };

            //apply for each number the expression, expected -> 4,9,16,25
            var squaredNumbers = numbers.Select(myExpression.Compile()); 
            //same as above but with different sintax
            var squaredNumbersTwo = numbers.Select(x => x * x); 
            
        }


        //LD TEST009 events and delegates. NOTE: is possible to achieve the same result with the code in "TEST007"
        private static void Test009()
        {
            //LD STEP 0 - call the class
            var video = new Video() { Title = "Video 1" };
            //LD declaring the Publisher
            var videoEncoder = new VideoEncoder(); 
            //LD declaring the two Subscribers
            var mailService = new MailService(); 
            var messageService = new MessageService(); 

            //LD STEP 1 - doing subscription of the method to the specific EVENT
            videoEncoder.VideoEncodedEvent += mailService.OnVideoEncoded;
            videoEncoder.VideoEncodedEvent += messageService.OnVideoEncoded;

            //LD STEP 2 - firing the event
            videoEncoder.Encode(video);

            //LD NOTE that the PUBLISHER never change
        }


        //LD TEST010 Extension Methods
        /// <summary>
        /// 1) I did declare another project having static class "MyExtensions" and static method "concatBookInfo", to be noticed the use of this. 
        ///    The method "concatBookInfo" extend the functionality of the class "BookLd"
        /// 2) in "Test010" I call the extension method as it was a method of the class.   
        /// </summary>
        private static void Test010()
        {
       
            //LD will write an extension method for the existing class "Book.cs". I want to concatenate all the informations related with a book
            BookLd aNewBook = new BookLd();
            aNewBook.title = "I Malavoglia";
            aNewBook.price = 10;

            System.Console.WriteLine(aNewBook.concatBookInfo());
        }

        /// <summary>
        /// //LD TEST011 yield
        /// </summary>
        private static void Test011()
        {
            //LD Test011_001 - fill values
            DisplayValues(simpleCaller(), "Simple Caller");

            //LD Test011_002
            DisplayValues(calleraskFilteredData(), "Filtered Data Caller");

            //LD Test011_003
            DisplayValues(calleraskFilteredDataYield(), "Filtered Data Caller Yield");

            //LD Test011_004
            DisplayValues(RunningTotal(), "Running Total");

            Console.ReadLine();
        }

        #region Test011 Support Methods

        static List<int> MyList = new List<int>();

        static void FillValues()
        {
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
        }

        static void DisplayValues(IEnumerable<int> aList, String prefixText)
        {
            foreach (int i in aList)
            {
                Console.WriteLine(prefixText + " -> " + i);
            }
        }

        static List<int> simpleCaller()
        {
            FillValues();
            return MyList;
        }

        static List<int> calleraskFilteredData()
        {
            List<int> temp = new List<int>();
            foreach (int i in MyList)
            {
                if (i > 3)
                {
                    temp.Add(i);
                }
            }
            return temp;
        }

        static IEnumerable<int> calleraskFilteredDataYield()
        {
            List<int> temp = new List<int>();
            foreach (int i in MyList)
            {
                if (i > 3) yield return i; //LD at any yield the framework does a return. I can avoid temp Collections to achieve the same.
            }
        }

        static IEnumerable<int> RunningTotal()
        {
            int runningtotal = 0;
            foreach (int i in MyList)
            {
                runningtotal += i;
                yield return (runningtotal);

            }
        }

        #endregion

        /// <summary>
        /// //LDTEST012 Implicit Conversions
        /// </summary>
        private static void Test012()
        {

            UserDefinedType udt = new UserDefinedType(5);

            //This call invokes the implicit "double" operator passing in input the user defined type
            double num = udt;

            //VICEVERSA, This call invokes the implicit "UserDefinedType" operator, I want "UserDefinedType" starting from the int "5"
            UserDefinedType udt2 = 5;

            Console.WriteLine("num = {0} dig2 = {1}", num, udt2.aNumber);
            Console.ReadLine();
        }

        #endregion

        #region region support methods

        //LD PREDICATE: this method example of a simple predicate returning a boolean
        static bool IsCheaperThan10Dollars(Book book1) {
            return book1.price < 10;
        }

        #endregion
    }
}
