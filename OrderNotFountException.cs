using System;
using System.Runtime.Serialization;

namespace ErrorHandling.Task1
{
    [Serializable]
    internal class OrderNotFountException : Exception
    {
        public OrderNotFountException()
        {
        }

        public OrderNotFountException(string message) : base(message)
        {
        }

        public OrderNotFountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderNotFountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}