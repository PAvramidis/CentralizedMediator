using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using CentralizedMediator.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Repository_Add_Generates_Event()
        {
            IEntity addedEntity = null;
            var entity = new Entity() { Id = 0 };

            var mediator = new RepositoryMediator<Entity>();
            var list = new List<Entity>();
            var repo = new Repository<Entity>(mediator, list);

            mediator.EntityAdded += (s, e) => addedEntity = e.AddedEntity;

            repo.Add(entity);

            Assert.AreEqual(entity, addedEntity);
        }

        [TestMethod]
        public void Repository_Delete_Generates_Event()
        {
            IEntity deletedEntity = null;
            var entity = new Entity() { Id = 0 };

            var mediator = new RepositoryMediator<Entity>();
            var list = new List<Entity>();
            var repo = new Repository<Entity>(mediator, list);

            mediator.EntityDeleted += (s, e) => deletedEntity = e.DeletedEntity;
            repo.Add(entity);

            repo.Delete(entity);

            Assert.AreEqual(entity, deletedEntity);
        }

        [TestMethod]
        public void Repository_Get_Generates_Event()
        {
            IEntity retrievedEntity = null;
            var entity = new Entity() { Id = 0 };

            var mediator = new RepositoryMediator<Entity>();

            var list = new List<Entity>();
            var repo = new Repository<Entity>(mediator, list);

            mediator.EntityRetrieved += (s, e) => retrievedEntity = e.RetrievedEntity;
            repo.Add(entity);
            repo.Get(0);

            Assert.AreEqual(entity, retrievedEntity);
        }

        [TestMethod]
        public void Can_Subscribe_To_Multiple_Repositories()
        {
            var entity = new Entity();
            var invocationCount = 0;

            var mediator = new RepositoryMediator<Entity>();

            var list1 = new List<Entity>();
            var list2 = new List<Entity>();
            var repo1 = new Repository<Entity>(mediator, list1);
            var repo2 = new Repository<Entity>(mediator, list2);

            mediator.EntityAdded += (s, e) => invocationCount++;

            repo1.Add(entity);
            repo1.Add(entity);
            repo2.Add(entity);

            Assert.AreEqual(3, invocationCount);
        }

        [TestMethod]
        public void Add_Should_Correctly_Add_The_Entity()
        {
            var mediator = new RepositoryMediator<Entity>();

            var list = new List<Entity>();
            var repo = new Repository<Entity>(mediator, list);
            var entity = new Entity() { Id = 0 };

            repo.Add(entity);

            Assert.AreSame(entity, list[0]);
        }

        [TestMethod]
        public void Delete_Should_Correctly_Delete_The_Entity()
        {
            var mediator = new RepositoryMediator<Entity>();
            var entity = new Entity() { Id = 0 };
            var list = new List<Entity>() { entity };
            var repo = new Repository<Entity>(mediator, list);

            repo.Delete(entity);

            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void Get_Should_Correctly_Get_The_Correct_Entity()
        {
            var mediator = new RepositoryMediator<Entity>();
            var entity = new Entity() { Id = 0 };
            var list = new List<Entity>() { entity };
            var repo = new Repository<Entity>(mediator, list);

            var result = repo.Get(0);

            Assert.AreEqual(entity, result);
        }

        [TestMethod]
        public void GetAll_Should_Correctly_Get_The_Relevant_Entities()
        {
            var mediator = new RepositoryMediator<Entity>();
            var entity1 = new Entity() { Id = 1 };
            var entity2 = new Entity() { Id = 2 };
            var entity3 = new Entity() { Id = 3 };
            var list = new List<Entity>() { entity1, entity2, entity3 };
            var repo = new Repository<Entity>(mediator, list);

            var result = repo.GetAll();

            CollectionAssert.AreEquivalent(list, result.ToList());
        }
    }
}
