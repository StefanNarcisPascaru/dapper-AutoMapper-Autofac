using System;

namespace PentaStagione.Infrastracture.Domain.BaseModels
{
    public class Entity : IEntity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
