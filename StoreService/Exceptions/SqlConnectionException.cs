using System;
using System.Runtime.Serialization;

namespace StoreService
{
    class SqlConnectionException : Exception
    {
        public SqlConnectionException()
            : base()
        {
        }

        public SqlConnectionException(string message) 
            : base(message)
        {
        }

        public SqlConnectionException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected SqlConnectionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
