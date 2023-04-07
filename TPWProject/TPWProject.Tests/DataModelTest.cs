using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWProject.Data;

namespace TPWProject.Tests
{
    [TestClass]
    public class DataModelTest
    {
        [TestMethod]
        public void CreateBallTest()
        {
            Ball testBall = new Ball(20, 20, 10, 10);
            Assert.IsTrue(testBall.Left == 20);
            Assert.IsTrue(testBall.Top == 20);
            testBall.Dispose();
        }

        //[TestMethod]
        //public void SetPositionBallTest()
        //{
        //    Ball testBall = new Ball(20, 20, 10, 10);
        //    testBall.Move(25, 30);
        //    Assert.IsTrue(testBall.Left == 25);
        //    Assert.IsTrue(testBall.Top == 30);
        //}
    }
}
