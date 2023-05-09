using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Tests
{
    [TestClass]
    public class DataApiTest
    {
        [TestMethod]
        public void CreateBallRepositoryTest()
        {
            IBall testBall = new Ball(20, 20, 10, 10);
            IBall testBall2 = new Ball(40, 40, 15, 15);
            IBallRepository ballRepository = new BallRepository();
            ballRepository.Add(testBall);
            ballRepository.Add(testBall2);
            Assert.AreEqual(ballRepository.Count(), 2);
            List<IBall> balls = ballRepository.GetAll();
            Assert.AreSame(balls[0], testBall);
            Assert.AreSame(balls[1], testBall2);
            ballRepository.Remove(testBall2);
            Assert.AreEqual(ballRepository.Count(), 1);
            ballRepository.Add(testBall2);
            ballRepository.RemoveAll();
            Assert.AreEqual(ballRepository.Count(), 0);

        }

        [TestMethod]
        public void DataAPITest()
        {
            DataAPI api = new DataAPI();
            api.CreateSimulation(200, 200, 2);
            Assert.IsNotNull(api);
            List<IBall> balls = api.GetBalls();
            Assert.AreEqual(balls.Count, 2);
            api.RemoveAllBalls();
            Assert.AreEqual(balls.Count, 0);
        }
    }
}
