using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using Moq;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void Store_GetById_Should_Use_The_Cache_If_Object_Is_Present()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var expected = new Entity() { Id = 0 };

            cacheHelper.Setup(c => c.GetFromCache(0)).Returns(expected);
            repo.Setup(r => r.Get(0)).Returns(default(Entity));

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            var result = store.GetById(0);

            Assert.AreSame(expected, result);
        }

        [TestMethod]
        public void Store_Add_Should_Add_The_Entity()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var entity = new Entity() { Id = 0 };

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            store.Add(entity);

            repo.Verify(r => r.Add(entity), Times.Once);
        }

        [TestMethod]
        public void Store_Delete_Should_Add_The_Entity()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var entity = new Entity() { Id = 0 };

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            store.Delete(entity);

            repo.Verify(r => r.Delete(entity), Times.Once);
        }
    }
}
