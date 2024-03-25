using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBPsoftTest2.Framework
{
    internal class NotSupportedDriverException : Exception
    {
        public NotSupportedDriverException() : base()
        {
        }

        public NotSupportedDriverException(DriverType driverType) 
            : base($"Driver {driverType} is not supported!")
        {

        }

        public NotSupportedDriverException(string message) : base(message)
        {

        }

        public NotSupportedDriverException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
