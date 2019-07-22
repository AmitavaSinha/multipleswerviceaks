using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPIService.Infrastructure.Exceptions
{
    public class GeneralException: Exception
    {
        public GeneralException()
        { }

        public GeneralException(string message)
            : base(message)
        { }

        public GeneralException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
