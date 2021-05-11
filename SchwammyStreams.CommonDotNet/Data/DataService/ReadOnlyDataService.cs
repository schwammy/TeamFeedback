using System.Collections.Generic;
using System.Threading.Tasks;
using SchwammyStreams.CommonDotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace SchwammyStreams.CommonDotNet.Data.DataService
{
    /// <summary>
    /// A simple data service for readonly data.
    /// </summary>
    /// <typeparam name="T">The entity type for the data service</typeparam>
    public interface IReadOnlyDataService<T> where T : Entity
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
    }

    /// <summary>
    /// A simple data service for readonly data.
    /// </summary>
    /// <typeparam name="T">The entity type for the data service</typeparam>
    public class ReadOnlyDataService<T> : IReadOnlyDataService<T> where T : Entity
    {
        private readonly IGenericReadonlyEntityRepository<T> _repository;

        /// <inheritdoc />
        public ReadOnlyDataService(IGenericReadonlyEntityRepository<T> repository)
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
    }
}
