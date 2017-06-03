using CentralizedMediator.Core.Interfaces;
using System;

namespace CentralizedMediator.Core.Events
{
    public class EntityDeletedEventArgs<T> : EventArgs where T : class, IEntity
    {
        public T DeletedEntity;
    }
}