﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    class DataBaseException : Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string message) : base(message)
        {
        }

        public DataBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
