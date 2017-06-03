using System;

namespace CentralizedMediator.Core
{
    public class EntityRetrievedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T RetrievedEntity;
    }
}