using CentralizedMediator.Core.Interfaces;
using System;

namespace CentralizedMediator.Core.Events
{
    public class EntityAddedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T AddedEntity;
    }
}