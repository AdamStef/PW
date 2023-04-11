using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Tests
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void CreateBallTest()
        {
            Ball testBall = new Ball(20, 20, 10, 10);
            Assert.IsTrue(testBall.Left == 20);
            Assert.IsTrue(testBall.Top == 20);
            Assert.IsTrue(testBall.Diameter == 10);
            Assert.IsTrue(testBall.Mass == 10);

        }

        [TestMethod]
        public void SetPositionBallTest()
        {
            Ball testBall = new Ball(20, 20, 10, 10);
            testBall.Top = 50;
            testBall.Left = 50;
            Assert.IsTrue(testBall.Left == 50);
            Assert.IsTrue(testBall.Top == 50);
        }

        [TestMethod]
        public void MoveTest()
        {
            Ball testBall = new Ball(100, 100, 10, 10);
            testBall.Move(250, 300);
            Assert.AreNotEqual(testBall.Left, 100);
            Assert.AreNotEqual(testBall.Top, 100);
        }

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
    }
}
