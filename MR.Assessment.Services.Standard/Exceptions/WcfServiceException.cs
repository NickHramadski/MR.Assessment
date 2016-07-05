using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MR.Assessment.Services.Standard.Exceptions
{
    public class WcfServiceException : Exception
    {
        public WcfServiceException()
        {
        }

        public WcfServiceException(string message) : base(message)
        {
        }

        public WcfServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WcfServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WcfServiceException(Exception exception) : base(exception.Message, exception)
        {
            
        }
    }
}
