using System;
using System.Runtime.Serialization;

namespace ErrorHandling.Task1
{
    [Serializable]
    internal class UserDaoNullException : Exception
    {
        public UserDaoNullException()
        {
        }

        public UserDaoNullException(string message) : base(message)
        {
        }

        public UserDaoNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserDaoNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}