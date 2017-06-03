using CentralizedMediator.Core.Interfaces;
using System.Collections.Generic;

namespace CentralizedMediator.Core
{
    public class Service<T> where T : class, IEntity
    {
        private IRepository<T> _repo;
        private IReadOnlyCacheHelper<T> _cacheHelper;

        public Service(IRepository<T> repo, IReadOnlyCacheHelper<T> cacheHelper)
        {
            _repo = repo;
            _cacheHelper = cacheHelper;
        }

        public T GetById(int id)
        {
            T entity = _cacheHelper.GetFromCache(id);

            if (entity != null) return entity;

            return _repo.Get(id);
        }

        public void Add(T entity)
        {
            // validate entity etc

            _repo.Add(entity);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
