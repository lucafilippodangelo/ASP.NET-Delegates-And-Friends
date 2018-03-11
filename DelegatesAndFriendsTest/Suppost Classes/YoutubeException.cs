using System;

namespace AdvancedCSharp
{
    //LD to create a CUSTOM EXCEPTION I need to declare a class that inherit from "Exception" and pass
    //the parameters to the base constructor
    class YoutubeException : Exception
    {
        public YoutubeException(string message, Exception innerException):base(message,innerException)
        { }
    }
}
