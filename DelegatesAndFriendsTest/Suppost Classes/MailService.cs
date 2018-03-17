using System;

namespace DelegatesAndFriendsTest.UsefulClasses
{
    public class MailService
    {
        //LD STEP 6 - create a METHOD SUBSCRIBER with the same signature of the DELEGATE
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailSerivice: Sending an Email..." + e.Video.Title );
        }
    }
}
