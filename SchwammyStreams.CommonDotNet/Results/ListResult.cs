using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SchwammyStreams.CommonDotNet.Results
{
    /// <summary>
    /// An object use to represent the result of an operation and return a list of value.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ListResult<TValue> : Result
    {
        public ListResult()
        {
            Values = new List<TValue>();
        }
        /// <summary>
        /// The values returned from the operation.
        /// </summary>
        public List<TValue> Values { get; set; }
    }
}
