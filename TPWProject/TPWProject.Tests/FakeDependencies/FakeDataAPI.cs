using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;

namespace TPWProject.Tests.FakeDependencies
{
    public class FakeDataAPI : AbstractDataAPI
    {
        private List<Shape> balls;

        public FakeDataAPI()
        {
            balls = new List<Shape>();
        }

        public override Shape GenerateBall(double height, double width)
        {
            Ball ball = new Ball(10, 10, 10, 10);
            balls.Add(ball);
            return ball;
        }

        public override IList<Shape> GetShapes()
        {
            return balls;
        }

        public override void RemoveAllShapes()
        {
            balls.Clear();
        }
    }
}
