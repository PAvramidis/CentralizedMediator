using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using Moq;
using CentralizedMediator.Core.Interfaces;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void Service_GetById_Should_Use_The_Cache_If_Object_Is_Present()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var expected = new Entity() { Id = 0 };

            cacheHelper.Setup(c => c.GetFromCache(0)).Returns(expected);

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            var result = store.GetById(0);

            Assert.AreSame(expected, result);
        }

        [TestMethod]
        public void Service_GetById_Should_Fallback_To_Repo_Is_Cache_Hit_Is_A_Miss()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var expected = new Entity() { Id = 0 };

            repo.Setup(r => r.Get(0)).Returns(expected);

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            var result = store.GetById(0);

            Assert.AreSame(expected, result);
        }

        [TestMethod]
        public void Store_Add_Should_Delegate_Addition_To_The_Repo()
        {
            var cacheHelper = new Mock<ICacheHelper<Entity>>();
            var repo = new Mock<IRepository<Entity>>();
            var entity = new Entity() { Id = 0 };

            var store = new Service<Entity>(repo.Object, cacheHelper.Object);

            store.Add(entity);

            repo.Verify(r => r.Add(entity), Times.Once);
        }

        [TestMethod]
        public void Store_Delete_Should_Delegate_Deletion_To_The_Repo()
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
