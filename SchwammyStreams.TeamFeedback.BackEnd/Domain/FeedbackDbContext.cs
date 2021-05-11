using System.Data;
using Microsoft.EntityFrameworkCore;
using SchwammyStreams.CommonDotNet.Data;

namespace SchwammyStreams.TeamFeedback.BackEnd.Domain
{
    public interface IFeedbackDbContext : IDbContext, IWriteableDbContext
    {
        DbSet<Feedback> Feedback { get; set; }
    }
    public class FeedbackDbContext : DbContext, IFeedbackDbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {

        }
        public IDbConnection DbConnection { get; set; }

        public DbSet<Feedback> Feedback { get; set; }
    }
}
