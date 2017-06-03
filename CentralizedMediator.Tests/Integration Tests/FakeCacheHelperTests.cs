using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using CentralizedMediator.Core.Interfaces;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class FakeCacheHelperTests
    {
        [TestMethod]
        public void FakeCacheHelper_Should_Correctly_Support_Caching()
        {
            var mediator = new RepositoryMediator<Entity>();
            var repo = new Repository<Entity>(mediator);
            var cacheHelper = new FakeCacheHelper<Entity>(mediator);

            var entity = new Entity() { Id = 0 };

            IEntity result;

            result = cacheHelper.GetFromCache(0);

            Assert.AreEqual(null, result);

            repo.Add(entity);

            result = cacheHelper.GetFromCache(0);

            Assert.AreEqual(entity, result);

            repo.Delete(entity);

            result = cacheHelper.GetFromCache(0);

            Assert.AreEqual(null, result);

            cacheHelper.Dispose();

            repo.Add(entity);

            result = cacheHelper.GetFromCache(0);

            Assert.AreEqual(null, result);
        }
    }
}
