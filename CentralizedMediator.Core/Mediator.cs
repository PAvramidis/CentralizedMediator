using System;
using System.Collections.Generic;

namespace CentralizedMediator.Core
{
    public class Mediator : ICentralizedMediator
    {
        private IDictionary<Type, IMediator> _mediators;

        public static readonly ICentralizedMediator Instance = new Mediator();

        private Mediator() {
            _mediators = new Dictionary<Type, IMediator>();
        }

        public T GetMediator<T>() where T: IMediator
        {
            return (T)_mediators[typeof(T)];
        }

        public void AddMediator(Type type, IMediator mediator)
        {
            _mediators.Add(type, mediator);
        }

        public void RemoveMediator(Type type)
        {
            _mediators.Remove(type);
        }

    }
}
