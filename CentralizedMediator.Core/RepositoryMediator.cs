using CentralizedMediator.Core.Events;
using CentralizedMediator.Core.Interfaces;
using System;

namespace CentralizedMediator.Core
{
    public sealed class RepositoryMediator<T> : IRepositoryMediator<T> where T: class, IEntity
    {
        public RepositoryMediator() { }

        public event EventHandler<EntityAddedEventArgs<T>> EntityAdded = delegate { };
        public event EventHandler<EntityRetrievedEventArgs<T>> EntityRetrieved = delegate { };
        public event EventHandler<EntityDeletedEventArgs<T>> EntityDeleted = delegate { };

        public void OnEntityAdded(object sender, EntityAddedEventArgs<T> args)
        {
            EntityAdded(sender, args);
        }

        public void OnEntityRetrieved(object sender, EntityRetrievedEventArgs<T> args)
        {
            EntityRetrieved(sender, args);
        }

        public void OnEntityDeleted(object sender, EntityDeletedEventArgs<T> args)
        {
            EntityDeleted(sender, args);
        }
    }
}
