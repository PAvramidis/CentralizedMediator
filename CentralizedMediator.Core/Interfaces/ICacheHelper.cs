using System;

namespace CentralizedMediator.Core.Interfaces
{
    public interface ICacheHelper<T> : IDisposable, IReadOnlyCacheHelper<T>
    {
        void ClearCache();
        int Count { get; }
    }
}
