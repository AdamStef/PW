using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TPWProject.Logic;

namespace TPWProject.Tests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GenerateBallsTest()
        {
            LogicAPI logicAPI = new LogicAPI(100, 100);
            logicAPI.GenerateBalls(2);
            Assert.AreEqual(logicAPI.GetShapes().Count(), 2);
        }

        [TestMethod]
        public void ClearRepositoryTest()
        {
            LogicAPI logicAPI = new LogicAPI(100, 100);
            logicAPI.GenerateBalls(2);
            logicAPI.ClearRepository();
            Assert.AreEqual(logicAPI.GetShapes().Count(), 0);
        }

        [TestMethod]
        public void StartStopMovementTest()
        {
            LogicAPI logicAPI = new LogicAPI(100, 100);
            logicAPI.GenerateBalls(2);
            logicAPI.StartBallMovement();
            Assert.IsTrue(logicAPI.isRunning);
            logicAPI.StopMovement();
            Assert.IsFalse(logicAPI.isRunning);
        }

        [TestMethod]
        public void SetDimensionsTest()
        {
            LogicAPI logicAPI = new LogicAPI(100, 100);
            logicAPI.SetDimentions(200, 200);
            Assert.AreEqual(logicAPI.height, 200);
            Assert.AreEqual(logicAPI.width, 200);
        }
    }
}
