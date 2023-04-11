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
        private List<Shape> balls;
        private double height;
        private double width;
        private bool isRunning = false;

        public override void ClearRepository()
        {
            balls.Clear();
        }

        public override void GenerateBalls(int ballsCount)
        {
            balls.Add(new Ball(10, 10, 10, 10));
        }

        public override IList<Shape> GetShapes()
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
