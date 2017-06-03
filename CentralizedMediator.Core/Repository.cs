using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedMediator.Core
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private List<T> _entities;
        private Mediator _mediator;

        public int Count { get { return _entities.Count; } }

        public Repository()
        {
            _entities = new List<T>();
            _mediator = Mediator.Instance;
        }
        
        public T Get(int id)
        {
            var entity = _entities[id];

            _mediator.OnEntityRetrieved(this, new EntityRetrievedEventArgs<IEntity>() { RetrievedEntity = entity });

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public bool Delete(T entity)
        {
            var result = _entities.Remove(entity);

            _mediator.OnEntityDeleted(this, new EntityDeletedEventArgs<IEntity>() { DeletedEntity = entity });

            return result;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);

            _mediator.OnEntityAdded(this, new EntityAddedEventArgs<IEntity>() { AddedEntity = entity });
        }
    }
}
