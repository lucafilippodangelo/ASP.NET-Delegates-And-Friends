using System;

namespace DelegatesAndFriendsTest.UsefulClasses
{

    class PhotoProcessor
    {
        //LD this DELEGATE is a pointer for methods that return a "void" and take a type "Photo"
        // not used, I CAN USE THE SHORT VERSION: "Action<Photo>". SEE BELOW
        //public delegate void PhotoFilterHandler(Photo photo); 

        public void Process(Action<Photo> filterHandler)
        {
            var photo = new Photo(); //LD creation of an instance of photo just for test

            ////LD with no delegates we have to apply the filters on server side
            //var filters = new photoFilter();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            ////LD here we apply the filters on client side

            //STEP005 all the methods attached to the delegate are called
            filterHandler(photo);// we RECEIVE the DELEGATE INSTANCE to the method, 
            // this code don't know which filter will be applied
            // THE RESPONSABILITY TO APPLY FILTERS IS OF THE CLIENT, and in this case 
            // by this "filterHandler(photo);" we will call all the methods pointed from 
            // the delegate and to everybody we will pass the "photo".


         
        }
    }
}
