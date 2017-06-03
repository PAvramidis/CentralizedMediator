using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedMediator.Core
{
    public partial class Mediator {
        public static readonly Mediator Instance = new Mediator();
        private Mediator() { } 
    }

    public partial class Mediator : IRepositoryMediator
    {
        public event EventHandler<EntityAddedEventArgs<IEntity>> EntityAdded = delegate { };
        public event EventHandler<EntityRetrievedEventArgs<IEntity>> EntityRetrieved = delegate { };
        public event EventHandler<EntityDeletedEventArgs<IEntity>> EntityDeleted = delegate { };

        public void OnEntityAdded(object sender, EntityAddedEventArgs<IEntity> args)
        {
            EntityAdded(sender, args);
        }

        public void OnEntityRetrieved(object sender, EntityRetrievedEventArgs<IEntity> args)
        {
            EntityRetrieved(sender, args);
        }

        public void OnEntityDeleted(object sender, EntityDeletedEventArgs<IEntity> args)
        {
            EntityDeleted(sender, args);
        }
    }
}
