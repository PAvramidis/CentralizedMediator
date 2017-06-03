using System;

namespace CentralizedMediator.Core
{
    public interface ICacheHelper<T> : IDisposable
    {
        void AddToCache(int id, T entity);
        void RemoveFromCache(int id);
        T GetFromCache(int id);
        void ClearCache();
        int Count { get; }
    }
}
