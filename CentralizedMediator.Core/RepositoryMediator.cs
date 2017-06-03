using System;

namespace CentralizedMediator.Core
{
    public class RepositoryMediator : IRepositoryMediator
    {
        public static readonly RepositoryMediator Instance = new RepositoryMediator();

        private RepositoryMediator() { }

        public event EventHandler<EntityAddedEventArgs<IEntity>> EntityAdded = delegate { };
        public event EventHandler<EntityRetrievedEventArgs<IEntity>> EntityRetrieved = delegate { };
        public event EventHandler<EntityDeletedEventArgs<IEntity>> EntityDeleted = delegate { };

        public void OnEntityAdded(object sender, EntityAddedEventArgs<IEntity> args)
        {
            EntityAdded(sender, args);
        }

        public void OnEntityRetrieved(object sender, EntityRetrievedEventArgs<IEntity> args)
        {
            EntityRetrieved(sender, args);
        }

        public void OnEntityDeleted(object sender, EntityDeletedEventArgs<IEntity> args)
        {
            EntityDeleted(sender, args);
        }
    }
}
