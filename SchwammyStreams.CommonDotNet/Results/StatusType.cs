using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.CommonDotNet.Results
{
    public enum StatusType
    {
        Success,
        BadRequest,
        Duplicate,
        NotFound,
        ValidationFailed,
        Unauthorized,
        Other
    }
}
