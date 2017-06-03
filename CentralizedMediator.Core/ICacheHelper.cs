using System;

namespace CentralizedMediator.Core
{
    public interface ICacheHelper<T> : IDisposable, IReadOnlyCacheHelper<T>
    {
        void AddToCache(int id, T entity);
        void RemoveFromCache(int id);
        void ClearCache();
        int Count { get; }
    }
}
