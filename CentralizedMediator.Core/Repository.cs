using System.Collections.Generic;
using System.Linq;

namespace CentralizedMediator.Core
{
    public sealed class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private List<T> _entities;
        private static ICentralizedMediator _mediator;

        public int Count { get { return _entities.Count; } }

        static Repository()
        {
            _mediator = Mediator.Instance;
            _mediator.AddMediator(typeof(IRepositoryMediator), RepositoryMediator.Instance);
        }

        public Repository()
        {
            _entities = new List<T>();
        }
        
        public T Get(int id)
        {
            var entity = _entities[id];

            _mediator.GetMediator<IRepositoryMediator>().OnEntityRetrieved(this, new EntityRetrievedEventArgs<IEntity>() { RetrievedEntity = entity });

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public bool Delete(T entity)
        {
            var result = _entities.Remove(entity);

            _mediator.GetMediator<IRepositoryMediator>().OnEntityDeleted(this, new EntityDeletedEventArgs<IEntity>() { DeletedEntity = entity });

            return result;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);

            _mediator.GetMediator<IRepositoryMediator>().OnEntityAdded(this, new EntityAddedEventArgs<IEntity>() { AddedEntity = entity });
        }
    }
}
