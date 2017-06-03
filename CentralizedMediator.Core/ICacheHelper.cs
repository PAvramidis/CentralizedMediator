using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedMediator.Core
{
    public interface ICacheHelper<T> : IDisposable
    {
        void AddToCache(int id, T entity);
        void RemoveFromCache(int id);
        void ClearCache();
        int Count { get; }
    }
}
