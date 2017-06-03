using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using Moq;
using CentralizedMediator.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void Service_Should_Support_Manipulating_Of_Entities()
        {
            var mediator = new RepositoryMediator<Entity>();
            var repo = new Repository<Entity>(mediator);
            var cacheHelper = new FakeCacheHelper<Entity>(mediator);
            var service = new Service<Entity>(repo, cacheHelper);
            var entity = new Entity() { Id = 0 };

            IEntity result;
            IEnumerable<IEntity> enumerable;
            IEntity[] array;

            result = service.GetById(0);

            Assert.AreEqual(null, result);

            service.Add(entity);

            result = service.GetById(0);

            Assert.AreEqual(entity, result);

            enumerable = service.GetAll();

            array = enumerable.ToArray();

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(entity, array[0]);

            service.Delete(entity);

            result = service.GetById(0);

            Assert.AreEqual(null, result);

            enumerable = service.GetAll();

            array = enumerable.ToArray();

            Assert.AreEqual(0, array.Length);

            cacheHelper.Dispose();

            service.Add(entity);

            result = service.GetById(0);

            Assert.AreEqual(entity, result);
        }
    }
}
