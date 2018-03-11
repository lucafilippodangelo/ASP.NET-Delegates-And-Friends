using System;

namespace DelegatesAndFriendsTest.UsefulClasses
{
    public class photoFilter
    {
        //public photoFilter(Photo photo)
        //{
        //    var _photo = photo;
        //}


        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply Brightness");
        }
        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }
        public void Resize(Photo photo)
        {
            Console.WriteLine("Apply Resize");
        }
    }
}
