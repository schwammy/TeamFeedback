using System.Collections.Generic;
using System.Threading.Tasks;
using SchwammyStreams.CommonDotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace SchwammyStreams.CommonDotNet.Data.DataService
{
    /// <summary>
    /// A simple data service for reading and writing entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataService<T> where T : Entity
    {
        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single entity</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Lists data, returns all items.
        /// </summary>
        /// <returns>a list of entities</returns>
        Task<List<T>> ListAsync();

        /// <summary>
        /// Adds a user
        /// </summary>
        /// <param name="user">the user to add</param>
        void Add(T user);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns></returns>
        Task<bool> DeleteUserAsync(int userId);
    }

    /// <inheritdoc />
    public class DataService<T> : IDataService<T> where T : Entity
    {
        private readonly IGenericWriteableRepository<T> _repository;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="repository"></param>
        public DataService(IGenericWriteableRepository<T> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public virtual async Task<T> GetAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        /// <inheritdoc />
        public virtual async Task<List<T>> ListAsync()
        {
            return await _repository.All.ToListAsync();
        }

        /// <inheritdoc />
        public virtual void Add(T user)
        {
            _repository.InsertOrUpdate(user);
        }

        /// <inheritdoc />
        public virtual async Task<bool> DeleteUserAsync(int userId)
        {
            return await _repository.DeleteAsync(userId);
        }
    }
}