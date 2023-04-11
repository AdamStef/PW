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
        private List<IBall> balls;

        public FakeDataAPI()
        {
            balls = new List<IBall>();
        }

        public override IBall GenerateBall(double height, double width)
        {
            Ball ball = new Ball(10, 10, 10, 10);
            balls.Add(ball);
            return ball;
        }

        public override IList<IBall> GetBalls()
        {
            return balls;
        }

        public override void RemoveAllBalls()
        {
            balls.Clear();
        }
    }
}
