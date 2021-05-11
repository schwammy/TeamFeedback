using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchwammyStreams.CommonDotNet.Data
{
    /// <summary>
    /// An interface to represent a repo that supports reading (only) entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericReadonlyEntityRepository<T> 
        : IGenericReadonlyRepository<T>,
            IGenericRepository<T>
    where T : Entity
    {

    }

    /// <summary>
    /// Interface for repositories that support read access to data via All or AllIncluding
    /// </summary>
    /// <typeparam name="TEntity">Data type for the repo.</typeparam>
    public interface IGenericReadonlyRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all data from a repository.
        /// </summary>
        IQueryable<TEntity> All { get; }
        /// <summary>
        /// Gets all data from a repository including populating specified properties.
        /// </summary>
        /// <param name="property">The property to load.</param>
        /// <returns>An IQueryable<typeparamref name="TEntity"/></returns>
        IQueryable<TEntity> AllIncluding(string property);
    }

    /// <summary>
    /// Interface for repositories that support async read access to data via All or AllIncluding where the class (T) implements IIntId.
    /// </summary>
    /// <typeparam name="TEntity">Data type for the repo.</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class, IIntId
    {
        /// <summary>
        /// Finds an item in the repository according to the Id (an int).
        /// </summary>
        /// <param name="id">The Id of the entity to search for.</param>
        /// <param name="cancellationToken">(Optional) A cancellation token to cancel the search.</param>
        /// <returns>The entity</returns>
        Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Interface for repositories that have asynchronous read/write access to data where the class (T) implements IIntId.
    /// </summary>
    /// <typeparam name="TEntity">Data type for the repo.</typeparam>
    public interface IGenericWriteableRepository<TEntity> : IGenericRepository<TEntity>, IGenericReadonlyRepository<TEntity> where TEntity : class, IIntId
    {
        /// <summary>
        /// Takes an Entity and saves it. If it is new, it is added. If it exists (by Id) it is an update.
        /// </summary>
        /// <param name="entity">The Entity to save.</param>
        /// <param name="forceSave">Will save changes to the DataContext immediately, without the need to call SaveChanges().</param>
        void InsertOrUpdate(TEntity entity, bool forceSave = false);

        /// <summary>
        /// Deletes an entity matching the Id.
        /// </summary>
        /// <param name="id">The Id of the Entity to delete.</param>
        /// <param name="cancellationToken">(Optional) Token used for cancellation.</param>
        /// <returns>A boolean value, true if the item is deleted, false if it is not.</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Interface for repositories that support executing stored procedures.
    /// </summary>
    public interface IStoredProcedureRepository
    {
        /// <summary>
        /// Executes a stored procedure that returns a result set.
        /// </summary>
        /// <typeparam name="TResult">The type of the result set of Entities from the data source.</typeparam>
        /// <param name="storedProcName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">An IEnumerable of SqlParameters to pass to the stored procedure.</param>
        /// <returns>The data set returned from the stored procedure.</returns>
        List<TResult> ExecuteStoredProc<TResult>(string storedProcName, IEnumerable<SqlParameter> parameters)
            where TResult : new();

        /// <summary>
        /// Executes a stored procedure that returns a scalar value.
        /// </summary>
        /// <typeparam name="TResult">The type of value to return.</typeparam>
        /// <param name="storedProcName">The name of the stored procedure to execute.</param>
        /// <param name="parameters">An IEnumerable of SqlParameters to pass to the stored procedure.</param>
        /// <returns>A scalar value returned by the stored procedure of type <typeparamref name="TResult"/></returns>
        TResult ExecuteScalarStoredProc<TResult>(string storedProcName, IEnumerable<SqlParameter> parameters);
    }
}
