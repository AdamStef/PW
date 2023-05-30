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
        public FakeDataAPI()
        {
            Boundary = new Boundary(0, 0);
        }

        public override void CreateSimulation(double height, double width, int ballCount)
        {
            Boundary = new Boundary(width, height);
            List<IBall> balls = Boundary.GetAll();
            for (int i = 0; i < ballCount; i++)
                balls.Add(new Ball(0, 0, 0, 0));
        }

        public override void EnableLogging(ILogger logger)
        {
            return;
        }

        public override List<IBall> GetBalls()
        {
            return Boundary.GetAll();
        }

        public override Boundary GetBoundary()
        {
            return Boundary;
        }

        public override void RemoveAllBalls()
        {
            Boundary.RemoveAll();
        }
    }
}
