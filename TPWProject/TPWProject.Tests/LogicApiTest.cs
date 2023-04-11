using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TPWProject.Logic;
using TPWProject.Tests.FakeDependencies;

namespace TPWProject.Tests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GenerateBallsTest()
        {
            var dataAPI = new FakeDataAPI();
            LogicAPI logicAPI = new LogicAPI(100, 100, dataAPI);
            logicAPI.GenerateBalls(2);
            Assert.AreEqual(logicAPI.GetBalls().Count(), 2);
        }

        [TestMethod]
        public void ClearRepositoryTest()
        {
            var dataAPI = new FakeDataAPI();
            LogicAPI logicAPI = new LogicAPI(100, 100, dataAPI);
            logicAPI.GenerateBalls(2);
            logicAPI.ClearRepository();
            Assert.AreEqual(logicAPI.GetBalls().Count(), 0);
        }

        [TestMethod]
        public void StartStopMovementTest()
        {
            var dataAPI = new FakeDataAPI();
            LogicAPI logicAPI = new LogicAPI(100, 100, dataAPI);
            logicAPI.GenerateBalls(2);
            logicAPI.StartBallMovement();
            Assert.IsTrue(logicAPI.IsRunning);
            logicAPI.StopMovement();
            Assert.IsFalse(logicAPI.IsRunning);
        }

        [TestMethod]
        public void SetDimensionsTest()
        {
            var dataAPI = new FakeDataAPI();
            LogicAPI logicAPI = new LogicAPI(100, 100, dataAPI);
            logicAPI.SetHeight(200);
            logicAPI.SetWidth(200);
            Assert.AreEqual(logicAPI.Height, 200);
            Assert.AreEqual(logicAPI.Width, 200);
        }
    }
}
