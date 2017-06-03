using CentralizedMediator.Core.Events;
using CentralizedMediator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedMediator.Core
{
    public sealed class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private List<T> _entities;
        private IRepositoryMediator<T> _mediator;

        public int Count { get { return _entities.Count; } }

        public Repository(IRepositoryMediator<T> mediator)
        {
            _mediator = mediator;
            _entities = new List<T>();
        }
        
        public T Get(int id)
        {
            T entity;

            try
            {
                // could be out of range
                entity = _entities[id];
                _mediator.OnEntityRetrieved(this, new EntityRetrievedEventArgs<T>() { RetrievedEntity = entity });
            }
            catch (Exception)
            {
                entity = null;
            }

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public bool Delete(T entity)
        {
            var result = _entities.Remove(entity);

            if (result)
            {
                _mediator.OnEntityDeleted(this, new EntityDeletedEventArgs<T>() { DeletedEntity = entity });

            }

            return result;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);

            _mediator.OnEntityAdded(this, new EntityAddedEventArgs<T>() { AddedEntity = entity });
        }
    }
}
