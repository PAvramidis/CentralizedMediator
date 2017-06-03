using System;

namespace CentralizedMediator.Core
{
    public interface ICacheHelper<T> : IDisposable, IReadOnlyCacheHelper<T>
    {
        void ClearCache();
        int Count { get; }
    }
}
