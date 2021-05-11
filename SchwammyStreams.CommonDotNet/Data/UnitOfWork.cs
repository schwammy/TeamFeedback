using System.Threading;
using System.Threading.Tasks;

namespace SchwammyStreams.CommonDotNet.Data
{
    public interface IUnitOfWork<TDbContext>
    {
        Task SaveAllAsync(CancellationToken cancellationToken = default);
    }

    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : IDbContext

    {
        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private TDbContext _dbContext;

        public async Task SaveAllAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContext is IWriteableDbContext writableDataContext)
            {
                await writableDataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
