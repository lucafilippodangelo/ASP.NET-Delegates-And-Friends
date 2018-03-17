using System;

namespace DelegatesAndFriendsTest.UsefulClasses
{
    class MessageService
    {
        //LD STEP 6 - create a METHOD SUBSCRIBER with the same signature of the DELEGATE
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Message Service: Sending a message..." + e.Video.Title  );
        }
    }
}
