using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Tests.FakeDependencies
{
    public class FakeLogicAPI : AbstractLogicAPI
    {
        List<IBall> balls;
        public double height;
        public double width;

        public FakeLogicAPI()
        {
            balls = new List<IBall>();
            height = 10;
            width = 10;
        }

        public override List<IBall> GetBalls()
        {
            return balls;
        }

        public override void SetHeight(double height)
        {
            this.height = height;
        }

        public override void SetWidth(double width)
        {
            this.width = width;
        }

        public override void StartSimulation(double height, double width, int ballCount)
        {
            IsRunning = true;
            for (int i = 0; i < ballCount; i++)
                balls.Add(new Ball(0, 0, 0, 0));
        }

        public override void StopSimulation()
        {
            IsRunning = false;
            balls.Clear();
        }
    }
}
