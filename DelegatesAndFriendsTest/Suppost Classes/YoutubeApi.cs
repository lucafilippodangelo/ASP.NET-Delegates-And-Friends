using System;

namespace AdvancedCSharp
{
    public class YoutubeApi
    {
        public void GetVideos()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                //LD we can log LOW LEVEN exception and trow the exception to a customized one
                //as second parameter we pass the actual exception.
                throw new YoutubeException("a customized error for youtube exception",ex);
                //LD so now the new message will be customized. this new exception that
                //I'm launching now will be catched by the caller "Try-Catch" block in "Program.cs"

            }
        }

    }
}
