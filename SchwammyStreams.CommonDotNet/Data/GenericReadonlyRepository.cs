using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// A generic repository that is readonly.
    /// </summary>
    /// <typeparam name="TEntity">The type of object stored in the repository.</typeparam>
    /// <typeparam name="TDbContext">The type of DbContext used by the repository.</typeparam>
    public class GenericReadonlyRepository<TEntity, TDbContext> : Repository<TDbContext>, IGenericReadonlyRepository<TEntity>
     where TEntity : class, IEntity
     where TDbContext : class, IDbContext
    {
        /// <summary>
        /// The DbSet that the repo is based on.
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Constructor that takes a dbcontext.
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericReadonlyRepository(TDbContext dbContext) : base(dbContext)
        {
            DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets all items from the repository.
        /// </summary>
        /// <value>An IQueryable of all items from the repository.</value>
        public IQueryable<TEntity> All
        {
            get { return DbSet; }
        }

        /// <summary>
        /// Gets all data from a repository including populating specified properties.
        /// </summary>
        /// <param name="property">Loads related objects according to the name supplied.</param>
        /// <returns>An IQueryable of all items from the repository.</returns>
        public IQueryable<TEntity> AllIncluding(string property)
        {
            return DbSet.Include(property);
        }
    }
}
