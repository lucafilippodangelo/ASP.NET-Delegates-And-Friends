using System;

namespace DelegatesAndFriendsTest.UsefulClasses
{

    class PhotoProcessor
    {
        //LD this DELEGATE is a pointer for methods that return a "void" and take a type "Photo"
        public delegate void PhotoFilterHandler(Photo photo); // not used, instead:
        //LD I CAN USE THE SHORT VERSION: "Action<Photo>"

        public void Process(Action<Photo> filterHandler)//BEFORE: public void Process(PhotoFilterHandler filterHandler)
        {
            var photo = new Photo();

            ////LD with no delegates we have to apply the filters on server side
            //var filters = new photoFilter();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            ////LD here we apply the filters on client side
            //WE JUST CALL THE DELEGATE RECEIVED
            filterHandler(photo);// we RECEIVE the DELEGATE INSTANCE to the method, 
            // this code don't know which filter will be applied
            // THE RESPONSABILITY TO APPLY FILTERS IS OF THE CLIENT, and in this case 
            // by this "filterHandler(photo);" we will call all the methods pointed from 
            // the delegate and to everybody we will pass the "photo".


         
        }
    }
}
