using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWProject.Presentation.Model;
using TPWProject.Tests.FakeDependencies;

namespace TPWProject.Tests
{
    [TestClass]
    public class ModelApiTest
    {
        [TestMethod]
        public void ModelAPITest()
        {
            var logicAPI = new FakeLogicAPI();
            AbstractModelAPI modelAPI = new ModelAPI(logicAPI);
            modelAPI.Start(100, 100, 2);
            Assert.AreEqual(modelAPI.GetBalls().Count, 2);
            modelAPI.Stop();
            Assert.AreEqual(modelAPI.GetBalls().Count, 0);
        }
    }
}
