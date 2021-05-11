using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchwammyStreams.CommonDotNet.Data
{
    public interface IEntity : IObjectState, IIntId
    {
    }

    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            ObjectState = ObjectState.Unchanged;
        }
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
