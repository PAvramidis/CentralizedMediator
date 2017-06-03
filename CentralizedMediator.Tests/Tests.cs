using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Repository_Add_Generates_Event()
        {
            IEntity addedEntity = null;
            var entity = new Entity() { Id = 0 };

            var repo = new Repository<Entity>();
            var mediator = Mediator.Instance;
            mediator.GetMediator<IRepositoryMediator>().EntityAdded += (s, e) => addedEntity = e.AddedEntity;

            repo.Add(entity);

            Assert.AreEqual(entity, addedEntity);
        }

        [TestMethod]
        public void Repository_Delete_Generates_Event()
        {
            IEntity deletedEntity = null;
            var entity = new Entity() { Id = 0 };

            var repo = new Repository<Entity>();
            var mediator = Mediator.Instance;
            mediator.GetMediator<IRepositoryMediator>().EntityDeleted += (s, e) => deletedEntity = e.DeletedEntity;

            repo.Delete(entity);

            Assert.AreEqual(entity, deletedEntity);
        }

        [TestMethod]
        public void Repository_Get_Generates_Event()
        {
            IEntity retrievedEntity = null;
            var entity = new Entity() { Id = 0 };

            var repo = new Repository<Entity>();
            var mediator = Mediator.Instance;
            mediator.GetMediator<IRepositoryMediator>().EntityRetrieved += (s, e) => retrievedEntity = e.RetrievedEntity;
            repo.Add(entity);
            repo.Get(0);

            Assert.AreEqual(entity, retrievedEntity);
        }

        [TestMethod]
        public void Can_Subscribe_To_Multiple_Repositories()
        {
            var entity = new Entity();
            var invocationCount = 0;
            var repo1 = new Repository<Entity>();
            var repo2 = new Repository<Entity>();
            var mediator = Mediator.Instance;
            mediator.GetMediator<IRepositoryMediator>().EntityAdded += (s, e) => invocationCount++;

            repo1.Add(entity);
            repo1.Add(entity);
            repo2.Add(entity);

            Assert.AreEqual(3, invocationCount);
        }
    }
}
