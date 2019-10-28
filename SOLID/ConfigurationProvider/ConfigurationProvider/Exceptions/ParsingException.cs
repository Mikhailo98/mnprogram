using System;

namespace SolidTask.ConfigurationProvider.Exceptions
{
    public class ParsingException : Exception
    {
        public ParsingException(string msg)
            : base(msg)
        {
        }

        public ParsingException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}