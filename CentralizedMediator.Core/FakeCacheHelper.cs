using System;
using System.Collections.Generic;

namespace CentralizedMediator.Core
{
    public class FakeCacheHelper : ICacheHelper<IEntity>
    {
        private IDictionary<int, IEntity> _cache;
        private IRepositoryMediator _repoMediator;

        public int Count { get { return _cache.Count;  } }

        public FakeCacheHelper(IRepositoryMediator repoMediator)
        {
            _repoMediator = repoMediator;
            _cache = new Dictionary<int, IEntity>();
        }

        public void InitializeListeners()
        {
            _repoMediator.EntityAdded += _repoMediator_EntityAdded;
            _repoMediator.EntityDeleted += _repoMediator_EntityDeleted;
            _repoMediator.EntityRetrieved += _repoMediator_EntityRetrieved;
        }

        public void Dispose()
        {
            _repoMediator.EntityAdded -= _repoMediator_EntityAdded;
            _repoMediator.EntityDeleted -= _repoMediator_EntityDeleted;
            _repoMediator.EntityRetrieved -= _repoMediator_EntityRetrieved;
        }

        private void _repoMediator_EntityRetrieved(object sender, EntityRetrievedEventArgs<IEntity> e)
        {
            var entity = e.RetrievedEntity;

            AddToCache(entity.Id, entity);
        }

        private void _repoMediator_EntityDeleted(object sender, EntityDeletedEventArgs<IEntity> e)
        {
            var entity = e.DeletedEntity;

            RemoveFromCache(entity.Id);
        }

        private void _repoMediator_EntityAdded(object sender, EntityAddedEventArgs<IEntity> e)
        {
            var entity = e.AddedEntity;

            AddToCache(entity.Id, entity);
        }

        public void AddToCache(int id, IEntity entity)
        {
            if (_cache.ContainsKey(entity.Id)) return;

            _cache.Add(id, entity);
        }

        public void ClearCache()
        {
            _cache.Clear();
        }

        public void RemoveFromCache(int id)
        {
            if (!_cache.ContainsKey(id)) return;

            _cache.Remove(id);
        }
    }
}
