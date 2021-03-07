using System;
using System.Runtime.Serialization;

namespace Foundation.Application
{
    [Serializable]
    public class CommandHandlingException : Exception
    {
        public CommandHandlingException()
        {
        }

        public CommandHandlingException(string message) : base(message)
        {
        }

        public CommandHandlingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CommandHandlingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}