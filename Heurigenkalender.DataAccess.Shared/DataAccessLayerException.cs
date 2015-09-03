using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.DataAccess.Shared
{
    public class DataAccessLayerException : Exception
    {
        public DataAccessLayerException() { }

        public DataAccessLayerException(string message = null)
            : base(message)
        { }
        public DataAccessLayerException(string message = null, Exception innerException = null)
            : base(message, innerException)
        { }
    }
}
