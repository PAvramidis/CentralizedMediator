using System;

namespace CentralizedMediator.Core
{
    public interface IRepositoryMediator
    {
        event EventHandler<EntityAddedEventArgs<IEntity>> EntityAdded;
        event EventHandler<EntityDeletedEventArgs<IEntity>> EntityDeleted;
        event EventHandler<EntityRetrievedEventArgs<IEntity>> EntityRetrieved;

        void OnEntityAdded(object sender, EntityAddedEventArgs<IEntity> args);
        void OnEntityDeleted(object sender, EntityDeletedEventArgs<IEntity> args);
        void OnEntityRetrieved(object sender, EntityRetrievedEventArgs<IEntity> args);
    }
}