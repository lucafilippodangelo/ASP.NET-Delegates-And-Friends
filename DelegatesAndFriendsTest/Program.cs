using AdvancedCSharp;
using DelegatesAndFriendsTest.UsefulClasses;
using System;

namespace DelegatesAndFriendsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test008();
        }//LD cose main


    
        #region region testing methods

        //LD linq
        private static void Test001()
        {
            LinqTests aLinqTestInstance = new LinqTests();
            aLinqTestInstance.LastExtensionMethod();
        }

        //LD nullable
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

        //LD generics
        private static void Test006()
        {
            //if for example I have two list, one of "int" and the second of "Book", and I want 
            //just ADD AN ITEM IN BOTH THE LISTS, I DON'T NEED OF TWO SEPARATED CLASSES

            //here we define the type of list, IT'S THE SAME LIKE WE USUALLY DO HERE: "var bla = new List<int>();"
            var numbers = new GenericListTest<int>(); 
            numbers.Add(23);// automatically it's suggested to pass an "int" parameter

            //LD we can use the same approach for a list of books, just by CHANGING the TEMPLATE PARAMETER
            var books = new GenericListTest<Book>();
            books.Add(new Book());
        }

        //LD delegates
        private static void Test007()
        {
            var aPhotoProcessorInstance = new PhotoProcessor();
            var filters = new photoFilter();

            //LD I need to create an instance of the DELEGATE and CONNECT with it the method that I want to call
            // in this case "ApplyBrightness" that has the same signature of the delegate "Action<Photo>" named "filterHandler" 
            Action<Photo> filterHandler = filters.ApplyBrightness;// BEFORE: PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            
            //LD now I add a POINTER
            filterHandler += filters.ApplyContrast;
            //LD THEN in the "processor" method we pass the "filterHandler" DELEGATE
            //that has correlated with him the methods to call
            aPhotoProcessorInstance.Process(filterHandler);
        }

        //LD lampda expression 
        private static void Test008()
        {
            // A, lampdaExpression sintax: "args => expression" , an example is "number => number*number"
            // B, we need to assign it to a system DELEGATE "Func", in our case gets and returns an "int"
            Func<int, int> myDelegateName = number => number * number;
            // C, then we call it
            Console.WriteLine(myDelegateName(6));

            //--------------------------------------------------------

            //// A, we want return the books cheaper than 10 dolars
            //// B, the traditional way:
            //var books = new BookRepository().GetBooks();
            //// C, a PREDICATE its a DELEGATE that point to a method that get a "book" in this case and RETURN a boolean that say if a GIVEN CONDITION is satisfied
            //// in this case I can call it like this:
            //var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            //// D, by using LAMPDA EXPRESSION
            //var cheapBooks2 = books.FindAll(b => b.price < 10);
        }

        private static void Test009()
        { }

        #endregion

    }
}
