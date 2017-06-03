using System;

namespace CentralizedMediator.Core
{
    public class EntityAddedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T AddedEntity;
    }
}