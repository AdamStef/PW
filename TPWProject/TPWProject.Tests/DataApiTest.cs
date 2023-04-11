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
            BallRepository ballRepository = new BallRepository();
            ballRepository.Add(testBall);
            ballRepository.Add(testBall2);
            Assert.AreEqual(ballRepository.Count(), 2);
            List<IBall> balls = (List<IBall>)ballRepository.GetAll();
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
            IBall testball = api.GenerateBall(30, 10);
            Assert.IsNotNull(api);
            Assert.IsNotNull(api.GenerateBall(10, 20));
            List<IBall> balls = (List<IBall>)api.GetBalls();
            Assert.AreSame(balls[0], testball);
            api.RemoveAllBalls();
            List<IBall> balls2 = (List<IBall>)api.GetBalls();
            Assert.IsFalse(balls2.Contains(testball));
        }
    }
}
