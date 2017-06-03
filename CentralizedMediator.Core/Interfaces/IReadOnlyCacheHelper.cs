using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedMediator.Core.Interfaces
{
    public interface IReadOnlyCacheHelper<T>
    {
        T GetFromCache(int id);
    }
}
