using System;
using System.Collections.Generic;

namespace CentralizedMediator.Core
{
    public sealed class Mediator : ICentralizedMediator
    {
        private IDictionary<Type, IMediator> _mediators;

        public static readonly ICentralizedMediator Instance = new Mediator();

        private Mediator() {
            _mediators = new Dictionary<Type, IMediator>();
        }

        public T GetMediator<T>() where T: class, IMediator
        {
            IMediator mediator;

            if (_mediators.TryGetValue(typeof(T), out mediator))
            {
                return (T)mediator;
            }

            return null;
        }

        public void AddMediator(Type type, IMediator mediator)
        {
            if (_mediators.ContainsKey(type)) return;

            _mediators.Add(type, mediator);
        }

        public void RemoveMediator(Type type)
        {
            if (!_mediators.ContainsKey(type)) return;

            _mediators.Remove(type);
        }

    }
}
