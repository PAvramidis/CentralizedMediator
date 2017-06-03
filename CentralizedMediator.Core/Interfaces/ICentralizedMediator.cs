using System;

namespace CentralizedMediator.Core.Interfaces
{
    public interface ICentralizedMediator
    {
        void AddMediator(Type type, IMediator mediator);
        T GetMediator<T>() where T : class, IMediator;
        void RemoveMediator(Type type);
    }
}