using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchwammyStreams.CommonDotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// A generic repository that supports reading and writing data.
    /// </summary>
    /// <typeparam name="TEntity">The type of object stored in the repository.</typeparam>
    /// <typeparam name="TDbContext">The type of DbContext used by the repository.</typeparam>
    public class GenericRepository<TEntity, TDbContext> : GenericReadonlyRepository<TEntity, TDbContext>, IGenericWriteableRepository<TEntity>
          where TEntity : class, IEntity
          where TDbContext : class, IDbContext
    {
        /// <summary>
        /// Constructor that takes a unit of work.
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Used to find an item in the repo according to it's Id.
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="cancellationToken">token for cancellation</param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Adds an item to a repository or updated it, if it already exists. Objects must implement IEntity (have an int Id).
        /// </summary>
        /// <param name="entity">Entity added or updated.</param>
        /// <param name="forceSave">Will save changes to the DataContext immediately, without the need to call SaveChanges().</param>
        public void InsertOrUpdate(TEntity entity, bool forceSave = false)
        {
            if (entity.Id == default || entity.Id < 0)
            {
                entity.ObjectState = ObjectState.Added;
                DbSet.Add(entity);
            }
            else
            {
                entity.ObjectState = ObjectState.Modified;
                DbSet.Attach(entity);
            }

            var implements = DbContext.GetType().GetInterfaces();

            if (implements.Any(i => i.Name == "IWriteableDbContext") && forceSave)
            {
                var count = ((IWriteableDbContext)DbContext).SaveChanges();
            }
        }


        /// <summary>
        /// Delete an item, asynchronously, from the repo according to Id.
        /// </summary>
        /// <param name="id">Id of the item to delete.</param>
        /// <param name="cancellationToken">(Optional) A token used to cancel the process if needed.</param>
        ///<returns>boolean value for success or failure</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var itemToRemove = await DbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);

            if (itemToRemove == null) return false;

            DbSet.Attach(itemToRemove);
            DbSet.Remove(itemToRemove);
            return true;
        }
    }
}
