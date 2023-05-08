using System;
using System.Collections.Generic;
using System.Diagnostics;
using TPWProject.Data;
using TPWProject.Data.Abstract;
using TPWProject.Logic.Abstract;

namespace TPWProject.Logic
{
    public class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        

        public LogicAPI(AbstractDataAPI dataAPI = null)
        {
            if (dataAPI != null)
                this.dataAPI = dataAPI;
            else
                this.dataAPI = AbstractDataAPI.CreateAPI();
        }

        public override void StartSimulation(double height, double width, int ballCount)
        {
            dataAPI.CreateSimulation(height, width, ballCount);
            foreach (Ball ball in dataAPI.GetBalls())
            {
                ball.BallPositionChanged += OnBallPositionChanged;
            }
        }

        public override void StopSimulation()
        {
            dataAPI.StopMovement();
            dataAPI.RemoveAllBalls();
        }


        public override List<IBall> GetBalls()
        {
            return dataAPI.GetBalls();
        }

        public override void SetHeight(double height)
        {
            dataAPI.GetBoundary().Height = height;
        }

        public override void SetWidth(double width)
        {
            dataAPI.GetBoundary().Width = width;
        }
        private void CheckBoundaryCollision(Ball ball)
        {
            if (ball.Top + ball.SpeedY <= 0)
            {
                ball.SpeedY *= -1;
                ball.Top = 0;
            }
            else if (ball.Top + ball.SpeedY + ball.Diameter >= dataAPI.Boundary.Height)
            {
                ball.SpeedY *= -1;
                ball.Top = dataAPI.Boundary.Height - ball.Diameter;
            }

            if (ball.Left + ball.SpeedX <= 0)
            {
                ball.SpeedX *= -1;
                ball.Left = 0;
            }
            else if (ball.Left + ball.SpeedX + ball.Diameter >= dataAPI.Boundary.Width)
            {
                ball.SpeedX *= -1;
                ball.Left = dataAPI.Boundary.Width - ball.Diameter;
            }
        }

        private void CheckBallsCollision(Ball ball)
        {
            foreach (Ball b in dataAPI.GetBalls())
            {
                if (b == ball)
                {
                    continue;
                }
                double xCenter = ball.Left + ball.Diameter / 2;
                double yCenter = ball.Top + ball.Diameter / 2;

                double distance = Math.Sqrt(Math.Pow(b.Left + (b.Diameter * 0.5) - xCenter, 2) + Math.Pow(b.Top + (b.Diameter * 0.5) - yCenter, 2));
                if (distance <= 0.5 * (b.Diameter + ball.Diameter))
                {
                    Collision(ball, b);
                }
            }
        }


        private void Collision(Ball b1, Ball b2)
        {
            double b1SpeedX = b1.SpeedX;
            double b2SpeedX = b2.SpeedX;

            double b1SpeedY = b1.SpeedY;
            double b2SpeedY = b2.SpeedY;

            b1.SpeedX = (b1SpeedX * (b1.Mass - b2.Mass) + 2 * b2.Mass * b2SpeedX) / (b1.Mass + b2.Mass);
            b2.SpeedX = (b2SpeedX * (b2.Mass - b1.Mass) + 2 * b1.Mass * b1SpeedX) / (b1.Mass + b2.Mass);

            b1.SpeedY = (b1SpeedY * (b1.Mass - b2.Mass) + 2 * b2.Mass * b2SpeedY) / (b1.Mass + b2.Mass);
            b2.SpeedY = (b2SpeedY * (b2.Mass - b1.Mass) + 2 * b1.Mass * b1SpeedY) / (b1.Mass + b2.Mass);
        }

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            CheckBoundaryCollision(ball);
            CheckBallsCollision(ball);
        }
    }
}