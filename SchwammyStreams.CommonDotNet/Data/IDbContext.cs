using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using System.Data;
using System.Threading; // test

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// An interface for DbContext
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Gets the Set<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">a class</typeparam>
        /// <returns>DbSet<typeparamref name="T"/></returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// The DbConnection used by the DbContext
        /// </summary>
        IDbConnection DbConnection { get; }

        /// <summary>
        /// The Database used by the DbContext
        /// </summary>
        DatabaseFacade Database { get; }
    }

    /// <summary>
    /// Interface for DbContext that supports write (add, update, delete).
    /// </summary>
    public interface IWriteableDbContext : IDbContext
    {
        /// <summary>
        /// Method to save changes to the DbContext
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Save changes to the DbContext asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>int</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
