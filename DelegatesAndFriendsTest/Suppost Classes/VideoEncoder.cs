using System;
using System.Threading;


/// <summary>
/// This class is a PUBLICHER, so when a video is encoded, this class has to notify
/// STEP 1 - define a delegate
/// STEP 2 - define an event based on the delegate
/// STEP 3 - raise an event by a method responsible for that
/// </summary>
namespace AdvancedCSharp.UsefulClasses
{
    public class VideoEncoder
    {
        //LD STEP 1 - per convention the first parameter is the source object or the class that is
        //rising the event, and the second parameter usually are other informations to add.
        //LD STEP 1 //public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        //LD STEP 8 - we change the delegate, instead to send "EventArgs" we send our custom "VideoEventArgs"
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs  args);

        //LD STEP 9 - is possible use the "EVENTHANDLER" class instead to declare iur custom delegate
        // so I can remove the "STEP 8" and the "STEP 2" just by writing
        //public event EventHandler<VideoEventArgs> VideoEncoded;

        //LD STEP 2 - 
        public event VideoEncodedEventHandler VideoEncoded;

         
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video....");
            Thread.Sleep(3000);
            Console.WriteLine("Video Encoded");
            OnVideoEncoded(video);
        }

        //LD STEP 3
        protected virtual void OnVideoEncoded(Video video)
        {
            //LD befor we check if there are SUBSCRIBER to this event
            if (VideoEncoded != null)
            {
                //LD then we call the event, by passing the right parameters
                //the source of the event is the same class "this".

                //LD STEP 4 - call the event when our event happen
                VideoEncoded(this, new VideoEventArgs() { Video=video });
            }
        }
    }
}
  