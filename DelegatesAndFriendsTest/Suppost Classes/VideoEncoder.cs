using System;
using System.Threading;


/// <summary>
/// This class is a PUBLISHER, so when a video is encoded, this class has to notify
/// STEP 1 - define a delegate
/// STEP 2 - define an event based on the delegate
/// STEP 3 - raise an event by a method responsible for that
/// </summary>
namespace DelegatesAndFriendsTest.UsefulClasses
{
    public class VideoEncoder
    {
        //LD STEP 1 - per convention the first parameter is the source object or the class that is
        //rising the event, and the second parameter usually are other informations to add.

        //LD STEP 2 
        public event VideoEncodedEventHandler VideoEncodedEvent;
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs  args); 
        //OPTION -> is possible use the "EVENTHANDLER" class instead to declare the custom delegate, so I could replace "STEP 2" with the below
        //public event EventHandler<VideoEventArgs> VideoEncoded;
         
        public void Encode(Video video)
        {
            Console.WriteLine("Video Encoded");

            //LD STEP 4 - call the event when the event happen
            VideoEncodedEvent(this, new VideoEventArgs() { Video = video });
        }

       
    }
}
  