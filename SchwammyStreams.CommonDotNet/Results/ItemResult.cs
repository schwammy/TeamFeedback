using System.Diagnostics.CodeAnalysis;

namespace SchwammyStreams.CommonDotNet.Results
{
    /// <summary>
    /// An object use to represent the result of an operation and return a single value.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ItemResult<TValue> : Result
    {
        public ItemResult()
        {
            Value = default(TValue);
        }
        /// <summary>
        /// The value returned from the operation.
        /// </summary>
        public TValue Value { get; set; }
    }

}
