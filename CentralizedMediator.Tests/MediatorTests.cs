using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralizedMediator.Core;
using CentralizedMediator.Core.Interfaces;

namespace CentralizedMediator.Tests
{
    [TestClass]
    public class MediatorTests
    {
        [TestMethod]
        public void Mediator_Should_Support_Storing_Of_Mediators()
        {
            var mediator = new Mediator();
            var repoMediator = new RepositoryMediator<Entity>();

            IMediator result;

            result = mediator.GetMediator<IRepositoryMediator<Entity>>();

            Assert.AreSame(null, result);

            mediator.AddMediator(typeof(IRepositoryMediator<Entity>), repoMediator);

            result = mediator.GetMediator<IRepositoryMediator<Entity>>();

            Assert.AreSame(repoMediator, result);

            mediator.RemoveMediator(typeof(IRepositoryMediator<Entity>));

            result = mediator.GetMediator<IRepositoryMediator<Entity>>();

            Assert.AreSame(null, result);
        }
    }
}
