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
        private List<IBall> balls;
        private double height;
        private double width;
        private bool isRunning = false;

        public FakeLogicAPI()
        {
            balls = new List<IBall>();
            this.height = 10;
            this.width = 10;
        }

        public override void ClearRepository()
        {
            balls.Clear();
        }

        public override void GenerateBalls(int ballsCount)
        {
            for (int i = 0; i < ballsCount; i++)
                balls.Add(new Ball(10, 10, 10, 10));
        }

        public override IList<IBall> GetBalls()
        {
            return balls;
        }

        public override double GetHeight()
        {
            return height;
        }

        public override bool GetIsRunning()
        {
            return isRunning;
        }

        public override double GetWidth()
        {
            return width;
        }

        public override void SetHeight(double height)
        {
            this.height = height;
        }

        public override void SetWidth(double width)
        {
            this.width = width;
        }

        public override void StartBallMovement()
        {
            isRunning = true;
        }

        public override void StopMovement()
        {
            isRunning = false;
        }
    }
}
