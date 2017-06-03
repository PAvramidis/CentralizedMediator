using CentralizedMediator.Core.Events;
using System;

namespace CentralizedMediator.Core.Interfaces
{
    public interface IRepositoryMediator<T> : IMediator where T: class, IEntity
    {
        event EventHandler<EntityAddedEventArgs<T>> EntityAdded;
        event EventHandler<EntityDeletedEventArgs<T>> EntityDeleted;
        event EventHandler<EntityRetrievedEventArgs<T>> EntityRetrieved;

        void OnEntityAdded(object sender, EntityAddedEventArgs<T> args);
        void OnEntityDeleted(object sender, EntityDeletedEventArgs<T> args);
        void OnEntityRetrieved(object sender, EntityRetrievedEventArgs<T> args);
    }
}