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
            Shape testBall = new Ball(20, 20, 10, 10);
            Shape testBall2 = new Ball(40, 40, 15, 15);
            BallRepository ballRepository = new BallRepository();
            ballRepository.Add(testBall);
            ballRepository.Add(testBall2);
            Assert.AreEqual(ballRepository.Count(), 2);
            List<Shape> balls = (List<Shape>)ballRepository.GetAll();
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
            Shape testball = api.GenerateBall(30, 10);
            Assert.IsNotNull(api);
            Assert.IsNotNull(api.GenerateBall(10, 20));
            List<Shape> balls = (List<Shape>)api.GetShapes();
            Assert.AreSame(balls[0], testball);
            api.RemoveAllShapes();
            List<Shape> balls2 = (List<Shape>)api.GetShapes();
            Assert.IsFalse(balls2.Contains(testball));
        }
    }
}
