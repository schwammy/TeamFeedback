using Microsoft.EntityFrameworkCore;
using System;

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// A helper class for converting ObjectState to EntityState
    /// </summary>
    public static class StateHelper
    {
        /// <summary>
        /// Converts ObjectState to EntityState
        /// </summary>
        /// <param name="state">The appropriate EntityState</param>
        /// <returns></returns>
        public static EntityState ConvertState(ObjectState state)
        {
            return state switch
            {
                ObjectState.Added => EntityState.Added,
                ObjectState.Modified => EntityState.Modified,
                ObjectState.Deleted => EntityState.Deleted,
                _ => EntityState.Unchanged
            };
        }

        /// <summary>
        /// Converts EntityState to ObjectState
        /// </summary>
        /// <param name="state">The appropriate ObjectState</param>
        /// <returns></returns>
        public static ObjectState ConvertState(EntityState state)
        {
            return state switch
            {
                EntityState.Detached => ObjectState.Unchanged,
                EntityState.Unchanged => ObjectState.Unchanged,
                EntityState.Added => ObjectState.Added,
                EntityState.Deleted => ObjectState.Deleted,
                EntityState.Modified => ObjectState.Modified,
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };
        }
    }
}
