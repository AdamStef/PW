using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Documents;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Logic;
using TPWProject.Logic.Abstract;
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
            AbstractLogicAPI logicAPI = new LogicAPI(dataAPI);
            logicAPI.StartSimulation(100, 100, 2);
            Assert.AreEqual(logicAPI.GetBalls().Count, 2);
        }

        [TestMethod]
        public void ClearRepositoryTest()
        {
            var dataAPI = new FakeDataAPI();
            AbstractLogicAPI logicAPI = new LogicAPI(dataAPI);
            logicAPI.StartSimulation(100, 100, 2);
            logicAPI.StopSimulation();
            Assert.AreEqual(logicAPI.GetBalls().Count, 0);
        }

        [TestMethod]
        public void StartStopSimulationTest()
        {
            var dataAPI = new FakeDataAPI();
            AbstractLogicAPI logicAPI = new LogicAPI(dataAPI);
            logicAPI.StartSimulation(100, 100, 2);
            Assert.IsTrue(logicAPI.IsRunning);
            logicAPI.StopSimulation();
            Assert.IsFalse(logicAPI.IsRunning);
        }

        [TestMethod]
        public void BoundaryCollisionTest()
        {
            Ball ball = new Ball(0, 50, 5, 5)
            {
                SpeedX = 1,
                SpeedY = -1,
            };


            var dataAPI = new FakeDataAPI();
            LogicAPI logicAPI = new LogicAPI(dataAPI);
            ball.BallPositionChanged += (sender, args) => 
            {
                logicAPI.CheckBoundaryCollision((Ball)sender);
            };

            ball.Move();

            Assert.AreEqual(ball.SpeedY, 1);
        }
    }
}
