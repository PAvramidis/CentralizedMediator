using CentralizedMediator.Core.Interfaces;
using System;

namespace CentralizedMediator.Core.Events
{
    public class EntityRetrievedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T RetrievedEntity;
    }
}