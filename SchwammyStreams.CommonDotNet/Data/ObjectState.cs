namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// An enum to track the state of an object within a Repo.
    /// </summary>
    public enum ObjectState
    {
        /// <summary>
        /// Added to the collection
        /// </summary>
        Added,
        /// <summary>
        /// Unchanged
        /// </summary>
        Unchanged,
        /// <summary>
        /// Modified
        /// </summary>
        Modified,
        /// <summary>
        /// Deleted
        /// </summary>
        Deleted
    }
}
