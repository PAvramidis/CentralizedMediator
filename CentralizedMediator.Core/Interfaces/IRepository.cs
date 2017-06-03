using System.Collections.Generic;

namespace CentralizedMediator.Core.Interfaces
{
    public interface IRepository<T>
    {
        int Count { get; }
        void Add(T entity);
        bool Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}