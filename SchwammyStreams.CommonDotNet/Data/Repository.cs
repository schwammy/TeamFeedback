using System;

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// Base class for a simple repository that has a DbContext
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class Repository<TDbContext> where TDbContext : class, IDbContext
    {
        /// <summary>
        /// The DbContext for the repo, it is pulled from the UnitOfWork.
        /// </summary>
        protected readonly TDbContext DbContext;

        /// <summary>
        /// Constructor for a basic repository
        /// </summary>
        /// <param name="dbContext">A DbContext.</param>
        public Repository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
