using CentralizedMediator.Core.Events;
using CentralizedMediator.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CentralizedMediator.Core
{
    public class FakeCacheHelper<T> : ICacheHelper<T> where T : class, IEntity
    {
        private IDictionary<int, T> _cache;
        private IRepositoryMediator<T> _repoMediator;

        public int Count { get { return _cache.Count;  } }

        public FakeCacheHelper(IRepositoryMediator<T> repoMediator)
        {
            _repoMediator = repoMediator;
            _cache = new Dictionary<int, T>();
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

        private void _repoMediator_EntityRetrieved(object sender, EntityRetrievedEventArgs<T> e)
        {
            var entity = e.RetrievedEntity;

            AddToCache(entity.Id, entity);
        }

        private void _repoMediator_EntityDeleted(object sender, EntityDeletedEventArgs<T> e)
        {
            var entity = e.DeletedEntity;

            RemoveFromCache(entity.Id);
        }

        private void _repoMediator_EntityAdded(object sender, EntityAddedEventArgs<T> e)
        {
            var entity = e.AddedEntity;

            AddToCache(entity.Id, entity);
        }

        private void AddToCache(int id, T entity)
        {
            if (_cache.ContainsKey(entity.Id)) return;

            _cache.Add(id, entity);
        }

        public void ClearCache()
        {
            
            _cache.Clear();
        }

        private void RemoveFromCache(int id)
        {
            if (!_cache.ContainsKey(id)) return;

            _cache.Remove(id);
        }

        public T GetFromCache(int id)
        {
            T entity;

            if (_cache.TryGetValue(id, out entity))
            {
                return entity;
            }
            
            return null;
        }
    }
}
