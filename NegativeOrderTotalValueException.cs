using System;
using System.Runtime.Serialization;

namespace ErrorHandling.Task1
{
    [Serializable]
    internal class NegativeOrderTotalValueException : Exception
    {
        public NegativeOrderTotalValueException()
        {
        }

        public NegativeOrderTotalValueException(string message) : base(message)
        {
        }

        public NegativeOrderTotalValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeOrderTotalValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}