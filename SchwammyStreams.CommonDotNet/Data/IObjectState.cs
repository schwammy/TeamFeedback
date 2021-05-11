namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// Interface for Objects that have an ObjectState property, used with Repository to track Added, Modified, Unchanged, Deleted
    /// </summary>
    public interface IObjectState
    {
        /// <summary>
        /// The state of the object according to EF.
        /// </summary>
        ObjectState ObjectState { get; set; }
    }
}
