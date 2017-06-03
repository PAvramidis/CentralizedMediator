using System;

namespace CentralizedMediator.Core
{
    public class EntityDeletedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T DeletedEntity;
    }
}